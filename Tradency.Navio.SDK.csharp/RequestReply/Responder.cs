using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Logging;
using Tradency.Navio.SDK.csharp.Basic;
using InnerRequest = Tradency.Navio.Grpc.Request;
using InnerResponse = Tradency.Navio.Grpc.Response;

namespace Tradency.Navio.SDK.csharp.RequestReply
{
    public class Responder : GrpcClient
    {
        private static ILogger logger;

        private readonly BufferBlock<InnerRequest> _RecivedRequests = new BufferBlock<InnerRequest>();
        private readonly BufferBlock<InnerResponse> _ResponsesToSend = new BufferBlock<InnerResponse>();

        public delegate Response RespondDelegate(Request request);


        public Responder(string NavioAddress = null)
        {
            _warpAddress = NavioAddress;

            InitLogger();
        }


        public void SubscribeToRequestsAsync(RespondDelegate handler, string channel, string group = "", string clientDisplayName = "")
        {
            logger.LogTrace($"Start Responder->SubscribeToRequestsAsync. Channel:'{channel}', Group:'{group}', client_tag:'{clientDisplayName}' ");

            try
            {
                // Start GRPC Listener Task
                var grpcTask = Task.Run(async () =>
                {
                    await GrpcListenAndRespondAsync(channel, group, clientDisplayName);
                });


                // send requests to end-user and post his response to queue
                CommunicationWithEndUser(handler);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in SubscribeToRequestsAsync");
            }
        }

        private async void CommunicationWithEndUser(RespondDelegate handler)
        {
            while (true)
            {
                // send requests to end-user and post his response to queue
                try
                {
                    // await for Request from queue
                    InnerRequest innerRequest = await _RecivedRequests.ReceiveAsync();

                    // Convert Tradency.Navio.Grpc.Request to outter Request
                    Request request = new Request(innerRequest);

                    // Activate end-user request handler and receive the response
                    Response response = handler(request);

                    // Convert
                    InnerResponse innerResponse = response.Convert();

                    // Send response - Add (Post) response to queue
                    _ResponsesToSend.Post(innerResponse);
                }
                catch (Exception ex)
                {
                    //throw ex;
                }
            }
        }


        private async Task GrpcListenAndRespondAsync(string channel, string group, string clientDisplayName)
        {   
            // metadata to pass over GRPC
            var metadata = new Metadata {
                { "client_tag", clientDisplayName },
                { "channel", channel },
                { "group", group }
            };

            // Open bidirectional streaming over GRPC
            using (var call = GetWarpGrpcClient().RequestResponseStream(metadata))
            {
                // write response from queue to GRPC stream
                var responseWriterTask = Task.Run(async () =>
                {
                    while (true)
                    {
                        // await for response in queue
                        InnerResponse response = await _ResponsesToSend.ReceiveAsync();
                        LogResponse(response);

                        // write response to GRPC stream
                        await call.RequestStream.WriteAsync(response);
                    }
                });

                // await for requests form GRPC stream.
                while (await call.ResponseStream.MoveNext())
                {
                    // Recived requests form GRPC stream.
                    InnerRequest request = call.ResponseStream.Current;

                    if (request.Body.IsEmpty)
                    {
                        // ignore 'keep alive' (empty) requests
                        continue;
                    }
                    LogRequest(request);

                    // Add (Post) request to queue
                    _RecivedRequests.Post(request);
                }
            }
        }

        private void LogRequest(InnerRequest request)
        {
            logger.LogTrace($"Responder InnerRequest. ID:'{request.ID}', Channel:'{request.Channel}', ReplyChannel:'{request.ReplyChannel}'");
        }

        private void LogResponse(InnerResponse response)
        {
            logger.LogTrace($"Responder InnerResponse. ID:'{response.RequestID}', ReplyChannel:'{response.ReplyChannel}'");
        }

        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            logger = loggerFactory.CreateLogger("Responder");
        }
    }
}
