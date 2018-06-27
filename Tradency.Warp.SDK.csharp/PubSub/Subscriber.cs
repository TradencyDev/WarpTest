using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
using Tradency.Warp.Grpc;
using Tradency.Warp.SDK.csharp.Tools;
using static Tradency.Warp.Grpc.warp;
using InnerMessage = Tradency.Warp.Grpc.Message;

namespace Tradency.Warp.SDK.csharp.PubSub
{
    public class Subscriber
    {
        private string _tbusAddress;
        private warpClient _client = null;
        private static ILogger logger;

        private readonly BufferBlock<InnerMessage> _RecivedMessages = new BufferBlock<InnerMessage>();

        public delegate void HandleMessageDelegate(Message message);

        public Subscriber(string warpAddress)
        {
            InitLogger();

            _tbusAddress = warpAddress;
        }


        public async void SubscribeToMessages(HandleMessageDelegate handler, string Channel, string Group = "", string clientDisplayName = "")
        {
            try
            {
                SubscribeToMessages(new SubscribeRequest() { Channel = Channel, Group = Group }, clientDisplayName);

                // send messages to end-user
                while (true)
                {
                    // await for message from queue
                    InnerMessage innerMessage = await _RecivedMessages.ReceiveAsync();

                    LogIncomingMessage(innerMessage); 

                    // Convert Tradency.Warp.Grpc.Message to outter Message
                    Message message = new Message(innerMessage);

                    // Activate end-user message handler Delegate
                    handler(message);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in SubscribeToMessages");
            }
        }

        private async void SubscribeToMessages(SubscribeRequest subscribeRequest, string clientDisplayName)
        {
            Metadata metadata = null;
            if (string.IsNullOrWhiteSpace(clientDisplayName))
            {
                metadata = new Metadata { { "client_tag", clientDisplayName } };
            }

            using (var call = GetTbusGrpcClient().SubscribeToChannel(subscribeRequest, metadata))
            {
                // Wait for message..
                while (await call.ResponseStream.MoveNext())
                {
                    // Recived a message
                    InnerMessage message = call.ResponseStream.Current;

                    // add message to queue
                    _RecivedMessages.Post(message);
                    LogIncomingMessage(message);
                }
            }
        }

        private void LogIncomingMessage(InnerMessage message)
        {
            //object objBody = Converter.FromByteArray(message.Body.ToByteArray());
            string objBody = "";
            logger.LogInformation($"PubsubSubscriber_Wrapper Recived Message: Metadata:'{message.Metadata}', Channel:'{message.Channel}', Body:'{objBody}'");
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

            logger.LogDebug("Subscriber: Opened connection to Warp server (ip:port) {0}", tbusAddress);

            return _client;
        }

        private string GetTbusAddress()
        {
            return _tbusAddress;
        }

        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            logger = loggerFactory.CreateLogger("Subscriber");
        }
    }
}
