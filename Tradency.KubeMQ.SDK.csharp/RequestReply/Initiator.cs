using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Tradency.KubeMQ.SDK.csharp.Basic;
using InnerRequest = KubeMQ.Grpc.Request;
using InnerResponse = KubeMQ.Grpc.Response;

namespace Tradency.KubeMQ.SDK.csharp.RequestReply
{
    public class Initiator : GrpcClient
    {
        private static ILogger logger;

        public delegate void HandleResponseDelegate(Response response);

        public Initiator(string KubeMQAddress = null)
        {
            InitLogger();

            _warpAddress = KubeMQAddress;
        }


        public async void SendRequest(HandleResponseDelegate handler, Request request, string clientDisplayName = "")
        {
            try
            {
                //LogRequest(request);

                Metadata metadata = null;
                if (string.IsNullOrWhiteSpace(clientDisplayName))
                {
                    metadata = new Metadata {{ "client_tag", clientDisplayName }};
                }

                InnerRequest innerRequest = request.Convert();

                // Send request and wait for response
                InnerResponse innerResponse = await GetWarpGrpcClient().SendRequestAsync(innerRequest, metadata);

                // convert InnerResponse to Response and return response to end user
                Response response = new Response(innerResponse);

                // send the response to the end-user response handler
                handler(response);

            }
            catch (RpcException ex)
            {
                logger.LogError($"Grpc Exception in SendRequest. Status: {ex.Status}");

                throw new RpcException(ex.Status);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in Initiator.SendRequest");

                throw ex;
            }
        }

        public async Task<Response> SendRequestAsync(Request request, string clientDisplayName = "")
        {
            try
            {
                //LogRequest(request);

                Metadata metadata = null;
                if (string.IsNullOrWhiteSpace(clientDisplayName))
                {
                    metadata = new Metadata { { "client_tag", clientDisplayName } };
                }

                InnerRequest innerRequest = request.Convert();
                
                // Send request and wait for response
                InnerResponse innerResponse = await GetWarpGrpcClient().SendRequestAsync(innerRequest, metadata);

                // convert InnerResponse to Response and return response to end user
                return new Response(innerResponse);
            }
            catch (RpcException ex)
            {
                logger.LogError($"Grpc Exception in SendRequestAsync. Status: {ex.Status}");

                throw new RpcException(ex.Status);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in Initiator.SendRequestAsync");
                return null;
            }
        }

        private void LogRequest(Request request)
        {
            logger.LogTrace($"Initiator->SendRequest. ID:'{request.ID}', Channel:'{request.Channel}', ReplyChannel:'{request.ReplyChannel}'");
        }

        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            logger = loggerFactory.CreateLogger("Initiator");
        }
    }
}
