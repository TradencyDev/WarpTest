﻿using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Logging;
using static Tradency.Warp.Grpc.warp;
using InnerRequest = Tradency.Warp.Grpc.Request;
using InnerResponse = Tradency.Warp.Grpc.Response;


namespace Tradency.Warp.SDK.csharp.RequestReply
{
    public class Responder
    {
        private string _tbusAddress;
        private warpClient _client = null;
        private static ILogger logger;

        private readonly BufferBlock<InnerRequest> _RecivedRequests = new BufferBlock<InnerRequest>();
        private readonly BufferBlock<InnerResponse> _ResponsesToSend = new BufferBlock<InnerResponse>();

        public delegate Response RespondDelegate(Request request);


        public Responder(string warpAddress)
        {
            _tbusAddress = warpAddress;

            InitLogger();
        }


        public async void SubscribeToRequestsAsync(RespondDelegate handler, string channel, string group = "", string clientDisplayName = "")
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
                while (true)
                {
                    // await for Request from queue
                    InnerRequest innerRequest = await _RecivedRequests.ReceiveAsync();

                    // Convert Tradency.Warp.Grpc.Request to outter Request
                    Request request = new Request(innerRequest);

                    // Activate end-user request handler and receive the response
                    Response response = handler(request);

                    // Convert
                    InnerResponse innerResponse = response.Convert();

                    // Send response - Add (Post) response to queue
                    _ResponsesToSend.Post(innerResponse);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in SubscribeToRequestsAsync");
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
            using (var call = GetTbusGrpcClient().RequestResponseStream(metadata))
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


        private warpClient GetTbusGrpcClient()
        {
            if (_client != null)
            {
                return _client;
            }

            // Open connection 
            string tbusAddress = GetTbusAddress();
            var channel = new Channel(tbusAddress, ChannelCredentials.Insecure);
            _client = new warpClient(channel);

            logger.LogDebug("Responder: Opened connection to Warp server (ip:port) {0}", tbusAddress);

            return _client;
        }

        private string GetTbusAddress()
        {
            return _tbusAddress;
        }

        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            logger = loggerFactory.CreateLogger("Responder");
        }
    }
}
