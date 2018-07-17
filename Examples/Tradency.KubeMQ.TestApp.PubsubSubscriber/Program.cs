using System;


namespace KubeMQ.csharp.TestApp.PubsubSubscriber
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
            PubsubSubscriber subscriber = new PubsubSubscriber();
            subscriber.SubscribeToMessages();
        }
    }
}
