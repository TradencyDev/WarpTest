using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
using KubeMQ.Grpc;
using Tradency.KubeMQ.SDK.csharp.Basic;
using Tradency.KubeMQ.SDK.csharp.Tools;
using InnerMessage = KubeMQ.Grpc.Message;

namespace Tradency.KubeMQ.SDK.csharp.PubSub
{
    public class Subscriber : GrpcClient
    {
        private static ILogger logger;

        private readonly BufferBlock<InnerMessage> _RecivedMessages = new BufferBlock<InnerMessage>();

        public delegate void HandleMessageDelegate(Message message);

        public Subscriber(string KubeMQAddress = null)
        {
            InitLogger();

            _warpAddress = KubeMQAddress;
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

                    // Convert KubeMQ.Grpc.Message to outter Message
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

            using (var call = GetWarpGrpcClient().SubscribeToChannel(subscribeRequest, metadata))
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
            logger.LogInformation($"Subscriber Recived Message: Metadata:'{message.Metadata}', Channel:'{message.Channel}', Body:'{objBody}'");
        }

        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            logger = loggerFactory.CreateLogger("Subscriber");
        }
    }
}
