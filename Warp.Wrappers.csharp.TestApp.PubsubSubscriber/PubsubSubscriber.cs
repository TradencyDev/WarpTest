using System;
using Microsoft.Extensions.Logging;
using Tradency.Warp.SDK.csharp.PubSub;
using Tools = Tradency.Warp.SDK.csharp.Tools;
using Warp.csharp.TestApp.Common;


namespace Warp.csharp.TestApp.PubsubSubscriber
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
            Subscriber wrapper = new Subscriber(serverAddress);

            // Subscribe
            string channel = "Sample.test1";
            wrapper.SubscribeToMessages(HandleIncomingMessage, channel);

            logger.LogTrace($"PubsubSubscriber Subscribe to channel {channel}.");
        }

        private void HandleIncomingMessage(Message message)
        {
            if (message != null)
            {
                string strMsg = string.Empty;
                object body = Tools.Converter.FromByteArray(message.Body);
                if (body is MyMessgae)
                {
                    strMsg = ((MyMessgae)body).ToString();
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
