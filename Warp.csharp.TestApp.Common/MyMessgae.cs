using System;
using Tools = Tradency.Warp.SDK.csharp.Tools;

namespace Warp.csharp.TestApp.Common
{
    [Serializable]
    public class MyMessgae
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
