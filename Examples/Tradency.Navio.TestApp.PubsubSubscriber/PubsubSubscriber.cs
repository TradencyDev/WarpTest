using System;
using Microsoft.Extensions.Logging;
using Tradency.Navio.SDK.csharp.PubSub;
using Tools = Tradency.Navio.SDK.csharp.Tools;
using Tradency.Navio.TestApp.Common;


namespace Navio.csharp.TestApp.PubsubSubscriber
{
    class PubsubSubscriber
    {
        private static ILogger logger;

        public PubsubSubscriber()
        {
            InitLogger();
        }

        public void SubscribeToMessages()
        {
            // init
            string serverAddress = "localhost:50000";
            Subscriber subscriber = new Subscriber(serverAddress);

            // Subscribe
            string channel = "Sample.test1";
            subscriber.SubscribeToMessages(HandleIncomingMessage, channel);

            logger.LogTrace($"PubsubSubscriber Subscribe to channel {channel}.");
        }

        private void HandleIncomingMessage(Message message)
        {
            if (message != null)
            {
                string strMsg = string.Empty;
                object body = Tools.Converter.FromByteArray(message.Body);
                if (body is MyMessage)
                {
                    strMsg = ((MyMessage)body).ToString();
                }
                else if (body is string)
                {
                    strMsg = body.ToString();
                }
                logger.LogInformation($"Enduser Recived Message: Metadata:'{message.Metadata}', Channel:'{message.Channel}', Body:'{strMsg}'");
            }
        }

        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory().AddConsole(LogLevel.Trace);
            logger = loggerFactory.CreateLogger("PubsubSubscriber");
        }
    }
}
