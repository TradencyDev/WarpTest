using System;
using Microsoft.Extensions.Logging;
using Tradency.Navio.SDK.csharp.PubSub;
using Tradency.Navio.TestApp.Common;
using Tools = Tradency.Navio.SDK.csharp.Tools;

namespace Navio.csharp.TestApp.PubsubSender
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
            Sender wrapper = new Sender(serverAddress);

            // SendMessage
            Message message1 = CreateSimpleStringMessage();

            try
            {
                wrapper.SendMessage(message1);

                logger.LogTrace($"PubsubSender send message 1, to channel {message1.Channel}.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in SendMessage");
            }

            Message message2 = CreateMessageWithObects();

            try
            {
                wrapper.SendMessage(message2);

                logger.LogTrace($"PubsubSender send message 2, to channel {message1.Channel}.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in SendMessage");
            }
        }

        private Message CreateSimpleStringMessage()
        {
            return new Message()
            {
                Channel = "Sample.test1",
                Metadata = "A sample string Metadata",
                Body = Tools.Converter.ToByteArray("Pubsub test message")
            };
        }

        private Message CreateMessageWithObects()
        {
            CustomMetadata metadata = new CustomMetadata() { MyProperty = 1, Info = "My info" };

            MyMessgae messgae = new MyMessgae() { intProperty = 99, strProperty = "message body" };

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
