using System;
using Tools = Tradency.Navio.SDK.csharp.Tools;

namespace Tradency.Navio.TestApp.Common
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
