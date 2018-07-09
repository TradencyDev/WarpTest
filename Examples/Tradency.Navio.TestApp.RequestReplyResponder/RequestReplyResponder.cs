using System;
using Microsoft.Extensions.Logging;
using Tradency.Navio.SDK.csharp.RequestReply;
using Tools = Tradency.Navio.SDK.csharp.Tools;
using Tradency.Navio.TestApp.Common;

namespace Navio.csharp.TestApp.RequestReplyResponder
{
    public class RequestReplyResponder
    {
        private static ILogger logger;

        public RequestReplyResponder()
        {
            InitLogger();
        }

        public void StartListening()
        {
            // init
            string serverAddress = "localhost:50000";
            Responder responder = new Responder(serverAddress);

            // Subscribe
            string channel = "MyChannel.SimpleRequest";
            responder.SubscribeToRequestsAsync(HandleIncomingRequests, channel);

            responder.SubscribeToRequestsAsync(HandleIncomingRequests, channel, "Group1", "clientDisplayName");
        }

        private Response HandleIncomingRequests(Request request)
        {
            string strBody = Tools.Converter.FromByteArray(request.Body).ToString();
            logger.LogDebug($"Respond to Request. ID:'{request.ID}', Channel:'{request.Channel}', Body:'{strBody}'");

            return new Response(request)
            {
                Metadata = "Response Metadata",
                Body = Tools.Converter.ToByteArray($"A Response to {request.ID}"),
                CacheHit = false
            };
        }


        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory().AddConsole(LogLevel.Trace);
            logger = loggerFactory.CreateLogger("RequestReplyResponder");
        }
    }
}
