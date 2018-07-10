using Google.Protobuf;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tradency.Navio.SDK.csharp.Tools
{
    public class Converter
    {
        /// <summary>
        /// Byte Array to ByteString
        /// </summary>
        internal static ByteString ToByteString(byte[] byteArray)
        {
            return ByteString.CopyFrom(byteArray);
        }

        /// <summary>
        /// Convert from byte array to object
        /// </summary>
        public static object FromByteArray(byte[] data)
        {
            if (data == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return obj;
            }
        }

        /// <summary>
        /// Convert from object to byte array
        /// </summary>
        public static byte[] ToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
