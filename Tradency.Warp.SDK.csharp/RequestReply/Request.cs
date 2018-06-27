using Google.Protobuf;
using System.Threading;
using InnerRequest = Tradency.Warp.Grpc.Request;

namespace Tradency.Warp.SDK.csharp.RequestReply
{
    public class Request
    {
        private static int _id = 0;

        #region C'Tors

        public Request() { }

        internal Request(InnerRequest innerRequest)
        {
            ID = string.IsNullOrEmpty(innerRequest.ID) ? GetNextId().ToString() : innerRequest.ID;//innerRequest.ID;// 
            Channel = innerRequest.Channel;
            Metadata = innerRequest.Metadata;
            Body = innerRequest.Body.ToByteArray();
            ReplyChannel = innerRequest.ReplyChannel;
            Timeout = innerRequest.Timeout;
            CacheKey = innerRequest.CacheKey;
            CacheTTL = innerRequest.CacheTTL;
        }

        internal InnerRequest Convert()
        {
            return new InnerRequest()
            {
                ID = GetNextId().ToString(),
                Channel = this.Channel,
                Metadata = this.Metadata,
                Body = ByteString.CopyFrom(this.Body),
                //ReplyChannel = this.ReplyChannel,
                Timeout = this.Timeout,
                CacheKey = this.CacheKey,
                CacheTTL = this.CacheTTL,
            };
        }
        #endregion

        #region Properties

        public string ID { get; set; }
        public string Channel { get; set; }
        public string Metadata { get; set; }
        public byte[] Body { get; set; }
        public string ReplyChannel { get; set; }
        public int Timeout { get; set; }
        public string CacheKey { get; set; }
        public int CacheTTL { get; set; } 
        #endregion

        private int GetNextId()
        {
            //return Interlocked.Increment(ref _id);

            int temp, temp2;

            do
            {
                temp = _id;
                temp2 = temp == ushort.MaxValue ? 1 : temp + 1;
            }
            while (Interlocked.CompareExchange(ref _id, temp2, temp) != temp);
            return _id;
        }
    }
}
