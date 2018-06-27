using Grpc.Core;
using System;
using Microsoft.Extensions.Logging;
using Tradency.Warp.SDK.csharp.Tools;
using static Tradency.Warp.Grpc.warp;
using InnerMessage = Tradency.Warp.Grpc.Message;

namespace Tradency.Warp.SDK.csharp.PubSub
{
    public class Sender
    {
        private string _tbusAddress;
        private warpClient _client = null;
        private static ILogger logger;

        public Sender(string warpAddress)
        {
            InitLogger();

            _tbusAddress = warpAddress;
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

                GetTbusGrpcClient().SendMessage(innerMessage, metadata);
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

            logger.LogDebug("Sender: Opened connection to Warp server (ip:port) {0}", tbusAddress);

            return _client;
        }

        private string GetTbusAddress()
        {
            return _tbusAddress;
        }

        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            logger = loggerFactory.CreateLogger("Sender");
        }
    }
}
