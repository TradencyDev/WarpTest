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

        public string Channel { get; set; }
        public string Metadata { get; set; }
        public byte[] Body { get; set; }
    }
}
