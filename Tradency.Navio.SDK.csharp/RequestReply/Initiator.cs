using System;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Tradency.Navio.Grpc;
using Tradency.Navio.SDK.csharp.Basic;
using InnerRequest = Tradency.Navio.Grpc.Request;
using InnerResponse = Tradency.Navio.Grpc.Response;

namespace Tradency.Navio.SDK.csharp.RequestReply
{
    public class Initiator : GrpcClient
    {
        private static ILogger logger;

        //public Initiator() { }

        public Initiator(string NavioAddress = null)
        {
            InitLogger();

            _warpAddress = NavioAddress;
        }

        public Response SendRequest(Request request, string clientDisplayName = "")
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
                InnerResponse innerResponse = GetWarpGrpcClient().SendRequest(innerRequest, metadata);

                // convert InnerResponse to Response and return response to end user
                return new Response(innerResponse);
            }
            catch (RpcException ex)
            {
                logger.LogError($"Grpc Exception in SendRequest. Status: {ex.Status}");

                throw new RpcException(ex.Status);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in Initiator.SendRequest");
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
