using Google.Protobuf;
using System.Threading;
using InnerRequest = Tradency.Navio.Grpc.Request;

namespace Tradency.Navio.SDK.csharp.RequestReply
{
    public class Request
    {
        private static int _id = 0;

        #region C'Tors

        public Request() { }

        internal Request(InnerRequest innerRequest)
        {
            ID = string.IsNullOrEmpty(innerRequest.ID) ? GetNextId().ToString() : innerRequest.ID; 
            Channel = innerRequest.Channel;
            Metadata = innerRequest.Metadata;
            Body = innerRequest.Body.ToByteArray();
            ReplyChannel = innerRequest.ReplyChannel;
            Timeout = innerRequest.Timeout;
            CacheKey = innerRequest.CacheKey;
            CacheTTL = innerRequest.CacheTTL;
        }

        /// <summary>
        /// Convert a Request to an InnerRequest
        /// </summary>
        /// <returns> An InnerRequest</returns>
        internal InnerRequest Convert()
        {
            return new InnerRequest()
            {
                ID = string.IsNullOrEmpty(ID) ? GetNextId().ToString() : ID,
                Channel = this.Channel,
                //ReplyChannel - Set only by Navio server
                Metadata = this.Metadata,
                Body = ByteString.CopyFrom(this.Body),
                Timeout = this.Timeout,
                CacheKey = this.CacheKey,
                CacheTTL = this.CacheTTL,
            };
        }
        #endregion

        
        #region Properties

        public string ID { get; set; }
        public string Channel { get; set; }
        public string ReplyChannel { get; private set; }
        public string Metadata { get; set; }
        public byte[] Body { get; set; }
        public int Timeout { get; set; }
        public string CacheKey { get; set; }
        public int CacheTTL { get; set; }
        #endregion

        /// <summary>
        /// Get an unique thread safety ID between 1 to 65535
        /// </summary>
        /// <returns></returns>
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
