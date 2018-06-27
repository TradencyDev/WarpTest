using System;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using static Tradency.Warp.Grpc.warp;
using InnerRequest = Tradency.Warp.Grpc.Request;
using InnerResponse = Tradency.Warp.Grpc.Response;

namespace Tradency.Warp.SDK.csharp.RequestReply
{
    public class Initiator
    {
        private string _tbusAddress;
        private warpClient _client = null;
        private static ILogger logger;

        public Initiator() { }

        public Initiator(string warpAddress)
        {
            InitLogger();

            _tbusAddress = warpAddress;
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
                InnerResponse innerResponse = GetTbusGrpcClient().SendRequest(innerRequest, metadata);

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
                logger.LogError(ex, "Exception in RequestReplyInitiator_Wrapper.SendRequest");
                return null;
            }
        }

        private void LogRequest(Request request)
        {
            logger.LogTrace($"Initiator->SendRequest. ID:'{request.ID}', Channel:'{request.Channel}', ReplyChannel:'{request.ReplyChannel}'");
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

            logger.LogDebug("Initiator: Opened connection to Warp server (ip:port) {0}", tbusAddress);

            return _client;
        }

        private string GetTbusAddress()
        {
            return _tbusAddress;
        }

        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            logger = loggerFactory.CreateLogger("Initiator");
        }
    }
}
