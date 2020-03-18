using System;

namespace RabbitMQPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            SendToQueue send = new SendToQueue();
            bool d = send.SendMessage("");

            ReceiveFromQueue receiveFrom = new ReceiveFromQueue();
            receiveFrom.ReceiveDataFromQueue();
        }
    }
}
