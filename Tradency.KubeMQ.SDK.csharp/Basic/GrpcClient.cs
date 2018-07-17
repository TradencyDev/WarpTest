using Grpc.Core;
using System;
using Microsoft.Extensions.Logging;
using Tradency.KubeMQ.SDK.csharp.Tools;
using static KubeMQ.Grpc.kubemq;

namespace Tradency.KubeMQ.SDK.csharp.Basic
{
    public class GrpcClient
    {
        protected string _warpAddress;
        protected kubemqClient _client = null;

        protected ILoggerFactory loggerFactory = new LoggerFactory();


        protected kubemqClient GetWarpGrpcClient()
        {
            if (_client != null)
            {
                return _client;
            }

            // Open connection 
            string warpAddress = GetWarpAddress();
            var channel = new Channel(warpAddress, ChannelCredentials.Insecure);
            _client = new kubemqClient(channel);

            //logger.LogDebug("Sender: Opened connection to KubeMQ server (ip:port) {0}", tbusAddress);

            return _client;
        }

        protected string GetWarpAddress()
        {
            string serverAddress = _warpAddress;

            if (!string.IsNullOrWhiteSpace(serverAddress))
                return serverAddress;

            serverAddress = ConfigurationLoader.GetServerAddress();

            if (string.IsNullOrWhiteSpace(serverAddress))
            {
                throw new Exception("Server Address was not supplied");
            }

            return serverAddress;
        }
    }
}
