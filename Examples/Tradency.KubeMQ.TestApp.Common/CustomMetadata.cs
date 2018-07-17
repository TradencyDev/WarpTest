using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradency.KubeMQ.TestApp.Common
{
    public class CustomMetadata
    {
        public int MyProperty { get; set; }
        public string Info { get; set; }

        public override string ToString()
        {
            return $"MyProperty:{MyProperty},Info:{Info}";
        }
    }
}
