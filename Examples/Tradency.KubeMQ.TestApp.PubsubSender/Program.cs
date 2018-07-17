using System;

namespace KubeMQ.csharp.TestApp.PubsubSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Starting...");
            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to stop the application...");
            Console.WriteLine();

            RunPubsubTest();


            Console.ReadLine();
        }

        static void RunPubsubTest()
        {
            PubsubSender pubsubSender = new PubsubSender();
            pubsubSender.SendMessage();

            pubsubSender.StreamMessages();
        }
    }
}
