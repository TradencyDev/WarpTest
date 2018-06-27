using System;
using Microsoft.Extensions.Logging;
using Tradency.Warp.SDK.csharp.RequestReply;
using Tools = Tradency.Warp.SDK.csharp.Tools;
using Warp.csharp.TestApp.Common;

namespace Warp.csharp.TestApp.RequestReplyResponder
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
            Responder listener = new Responder(serverAddress);

            // Subscribe
            string channel = "MyChannel.SimpleRequest";
            listener.SubscribeToRequestsAsync(HandleIncomingRequests, channel);
        }

        private Response HandleIncomingRequests(Request request)
        {
            string strBody = Tools.Converter.FromByteArray(request.Body).ToString();
            logger.LogDebug($"Respond to Request. ID:'{request.ID}', Channel:'{request.Channel}', Body:'{strBody}'");

            return new Response(request)
            {
                Metadata = "Response Metadata",
                Body = Tools.Converter.ToByteArray($"A Response to {request.ID}"),
                ChachHit = false
            };
        }


        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory().AddConsole(LogLevel.Trace);
            logger = loggerFactory.CreateLogger("RequestReplyResponder");
        }
    }
}
