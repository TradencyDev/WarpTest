using Grpc.Core;
using System;
using Microsoft.Extensions.Logging;
using Tradency.KubeMQ.SDK.csharp.Basic;
using Tradency.KubeMQ.SDK.csharp.Tools;
using InnerMessage = KubeMQ.Grpc.Message;

namespace Tradency.KubeMQ.SDK.csharp.PubSub
{
    public class Sender : GrpcClient
    {
        private static ILogger logger;

        public Sender(string KubeMQAddress = null) 
        {
            InitLogger();

            _warpAddress = KubeMQAddress;
        }

        public void SendMessage(Message message, string clientDisplayName = "")
        {
            try
            {
                InnerMessage innerMessage = message.ToInnerMessage();

                Metadata metadata = null;
                if (string.IsNullOrWhiteSpace(clientDisplayName))
                {
                    metadata = new Metadata { { "client_tag", clientDisplayName } };
                }

                GetWarpGrpcClient().SendMessage(innerMessage, metadata);
            }
            catch (RpcException ex)
            {
                logger.LogError(ex, "Exception in SendMessage");

                throw new RpcException(ex.Status);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in SendMessage");

                throw new Exception(ex.Message);
            }
        }

        public async void StreamMessage(Message message, string clientDisplayName = "")
        {
            try
            {
                InnerMessage innerMessage = message.ToInnerMessage();

                Metadata metadata = null;
                if (string.IsNullOrWhiteSpace(clientDisplayName))
                {
                    metadata = new Metadata { { "client_tag", clientDisplayName } };
                }

                await GetWarpGrpcClient().SendMessageStream(metadata).RequestStream.WriteAsync(innerMessage);
            }
            catch (RpcException ex)
            {
                logger.LogError(ex, "Exception in StreamMessage");

                throw new RpcException(ex.Status);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in StreamMessage");

                throw new Exception(ex.Message);
            }
        }

        public async void ClosesMessageStreamAsync()
        {
            await GetWarpGrpcClient().SendMessageStream().RequestStream.CompleteAsync();
        }

        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            logger = loggerFactory.CreateLogger("Sender");
        }
    }
}
