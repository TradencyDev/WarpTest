using System;
using System.Threading;
using Microsoft.Extensions.Logging;
using Tradency.KubeMQ.SDK.csharp.PubSub;
using Tradency.KubeMQ.TestApp.Common;
using Tools = Tradency.KubeMQ.SDK.csharp.Tools;

namespace KubeMQ.csharp.TestApp.PubsubSender
{
    class PubsubSender
    {

        private static ILogger logger;

        public PubsubSender()
        {
            InitLogger();
        }

        public void SendMessage()
        {
            // init
            string serverAddress = "localhost:50000";
            Sender sender = new Sender(serverAddress);

            // SendMessage
            Message message1 = CreateSimpleStringMessage();

            try
            {
                sender.SendMessage(message1);

                logger.LogTrace($"PubsubSender send message 1, to channel {message1.Channel}.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in SendMessage");
            }

            Message message2 = CreateMessageWithObects();

            try
            {
                sender.SendMessage(message2);

                logger.LogTrace($"PubsubSender send message 2, to channel {message1.Channel}.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in SendMessage");
            }
        }

        public void StreamMessages()
        {
            // init
            string serverAddress = "localhost:50000";
            Sender sender = new Sender(serverAddress);

            Message message;

            for (int i = 1; i < 11; i++)
            {
                message = CreateSimpleStringMessage(i);

                sender.StreamMessage(message);

                Thread.Sleep(1000);
            }
            sender.ClosesMessageStreamAsync();

            message = CreateSimpleStringMessage(99);
            sender.SendMessage(message);
        }

        private Message CreateSimpleStringMessage(int i = 0)
        {
            return new Message()
            {
                Channel = "Sample.test1",
                Metadata = "A sample string Metadata",
                Body = Tools.Converter.ToByteArray("Pubsub test message "+ i)
            };
        }

        private Message CreateMessageWithObects()
        {
            CustomMetadata metadata = new CustomMetadata() { MyProperty = 1, Info = "My info" };

            MyMessage messgae = new MyMessage() { intProperty = 99, strProperty = "message body" };

            return new Message()
            {
                Channel = "Sample.test1",
                Metadata = metadata.ToString(),
                Body = messgae.ToByteArray()
            };
        }

        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory().AddConsole(LogLevel.Trace);
            logger = loggerFactory.CreateLogger("PubsubSender");
        }
    }
}
