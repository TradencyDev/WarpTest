using Google.Protobuf;
using InnerResponse = Tradency.Warp.Grpc.Response;

namespace Tradency.Warp.SDK.csharp.RequestReply
{
    public class Response
    {
        #region C'Tors
        internal Response() { }

        internal Response(InnerResponse inner)
        {
            RequestID = inner.RequestID;
            ReplyChannel = inner.ReplyChannel;
            Metadata = inner.Metadata;
            Body = inner.Body.ToByteArray();
            ChachHit = inner.ChachHit;
        }

        public Response(Request request)
        {
            RequestID = request.ID;
            ReplyChannel = request.ReplyChannel;
        }

        #endregion

        internal InnerResponse Convert()
        {
            return new InnerResponse()
            {
                RequestID = this.RequestID,
                ReplyChannel = ReplyChannel,
                Metadata = this.Metadata,
                Body = ByteString.CopyFrom(this.Body),
                ChachHit = this.ChachHit
            };
        }

        #region Properties
        public string RequestID { get; set; }
        public string ReplyChannel { get; set; }
        public string Metadata { get; set; }
        public byte[] Body { get; set; }
        public bool ChachHit { get; set; }
        #endregion
    }
}
