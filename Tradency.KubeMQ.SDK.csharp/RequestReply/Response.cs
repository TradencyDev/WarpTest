using Google.Protobuf;
using InnerResponse = KubeMQ.Grpc.Response;

namespace Tradency.KubeMQ.SDK.csharp.RequestReply
{
    public class Response
    {
        #region C'Tors

        public Response(Request request)
        {
            RequestID = request.ID;
            ReplyChannel = request.ReplyChannel;
        }

        internal Response(InnerResponse inner)
        {
            RequestID = inner.RequestID;
            ReplyChannel = inner.ReplyChannel;
            Metadata = inner.Metadata;
            Body = inner.Body.ToByteArray();
            CacheHit = inner.CacheHit;
        }

        #endregion

        internal InnerResponse Convert()
        {
            return new InnerResponse()
            {
                RequestID = this.RequestID,
                ReplyChannel = this.ReplyChannel,
                Metadata = this.Metadata,
                Body = ByteString.CopyFrom(this.Body),
                CacheHit = this.CacheHit
            };
        }

        private string ReplyChannel { get; set; }

        #region public Properties
        public string RequestID { get; set; }
        public string Metadata { get; set; }
        public byte[] Body { get; set; }
        public bool CacheHit { get; set; }
        #endregion
    }
}
