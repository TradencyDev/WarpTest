using System;
using Tools = Tradency.KubeMQ.SDK.csharp.Tools;

namespace Tradency.KubeMQ.TestApp.Common
{
    [Serializable]
    public class MyMessage
    {
        public int intProperty { get; set; }
        public string strProperty { get; set; }

        public byte[] ToByteArray()
        {
            return Tools.Converter.ToByteArray(this);
        }

        public override string ToString()
        {
            return $"intProperty:{intProperty},strProperty:{strProperty}";
        }
    }
}
