using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubeMQ.csharp.TestApp.RequestReplyResponder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Starting...");
            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to stop the application...");

            RunRequestTest();

            Console.ReadLine();
        }

        static void RunRequestTest()
        {
            RequestReplyResponder responder = new RequestReplyResponder();
            responder.StartListening();
        }
    }
}
