﻿using Tradency.Navio.SDK.csharp.Tools;
using InnerMessage = Tradency.Navio.Grpc.Message;

namespace Tradency.Navio.SDK.csharp.PubSub
{
    public class Message
    {
        public Message() { }

        internal Message(InnerMessage innerMessage)
        {
            Channel = innerMessage.Channel;
            Metadata = innerMessage.Metadata;
            Body = innerMessage.Body.ToByteArray();
        }

        internal InnerMessage ToInnerMessage()
        {
            return new InnerMessage()
            {
                Channel = this.Channel,
                Metadata = this.Metadata,
                Body = Converter.ToByteString(this.Body)
            };
        }

        public string Channel { get; set; }
        public string Metadata { get; set; }
        public byte[] Body { get; set; }
    }
}
