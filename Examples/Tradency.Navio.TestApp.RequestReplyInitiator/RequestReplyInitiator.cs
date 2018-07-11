using System;
using Microsoft.Extensions.Logging;
using Tradency.Navio.SDK.csharp.RequestReply;
using Tools = Tradency.Navio.SDK.csharp.Tools;
using Tradency.Navio.TestApp.Common;

namespace Navio.csharp.TestApp.RequestReplyInitiator
{
    public class RequestReplyInitiator
    {
        private static ILogger logger;

        public RequestReplyInitiator()
        {
            InitLogger();
        }

        public async void SendRequestAsync()
        {
            // init
            string serverAddress = "localhost:50000";
            Initiator initiator = new Initiator(serverAddress);

            // Send Request Async and await for response
            Request request = CreateSimpleRequest();

            try
            {
                Response response = await initiator.SendRequestAsync(request);

                LogResponse(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in SendRequest");
            }


            // Send Request with delegate to handle the responses
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    Request request2 = CreateRequestWithObjects(i);
                    initiator.SendRequest(HandleResponse, request2);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in SendRequest");
            }
        }

        // Method to handle the responses
        public void HandleResponse(Response response)
        {
            LogResponse(response);
        }

        private Request CreateSimpleRequest()
        {
            return new Request()
            {
                Channel = "MyChannel.SimpleRequest",
                Metadata = "MyMetadata",
                Body = Tools.Converter.ToByteArray("A Simple Request."),
                Timeout = 5000,
                CacheKey = "",
                CacheTTL = 0
            };
        }

        private Request CreateRequestWithObjects(int i)
        {
            CustomMetadata metadata = new CustomMetadata() { MyProperty = i, Info = "My info" };

            MyMessage messgae = new MyMessage() { intProperty = i, strProperty = $"Request {i}" };

            return new Request()
            {
                Channel = "MyChannel.SimpleRequest",
                Metadata = metadata.ToString(),
                Body = messgae.ToByteArray(),
                Timeout = 5000,
                CacheKey = "key_"+i,
                CacheTTL = 5000 // Millisecond
            };
        }

        private void LogResponse(Response response)
        {
            string strBody = Tools.Converter.FromByteArray(response.Body).ToString();
            logger.LogDebug($"Response: RequestID:'{response.RequestID}', Metadata:'{response.Metadata}', Body:'{strBody}' ");
        }

        private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory().AddConsole(LogLevel.Trace);
            logger = loggerFactory.CreateLogger("RequestReplyInitiator");
        }
    }
}
