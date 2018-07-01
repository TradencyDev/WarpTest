using Grpc.Core;
using System;
using Microsoft.Extensions.Logging;
using Tradency.Navio.SDK.csharp.Basic;
using Tradency.Navio.SDK.csharp.Tools;
using InnerMessage = Tradency.Navio.Grpc.Message;

namespace Tradency.Navio.SDK.csharp.PubSub
{
    public class Sender : GrpcClient
    {
        private static ILogger logger;

        public Sender(string NavioAddress = null) 
        {
            InitLogger();

            _warpAddress = NavioAddress;
        }

        public void SendMessage(Message message, string clientDisplayName = "")
        {
            try
            {
                InnerMessage innerMessage = new InnerMessage()
                {
                    Channel = message.Channel,
                    Metadata = message.Metadata,
                    Body = Converter.ToByteString(message.Body)
                };

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

        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            logger = loggerFactory.CreateLogger("Sender");
        }
    }
}
