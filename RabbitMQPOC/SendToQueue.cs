using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQPOC
{
    public class SendToQueue
    {
        public bool SendMessage(string message)
        {
            bool temp = false;
            var connFactory = new RabbitMQ.Client.ConnectionFactory() { HostName = "localhost" };
            using (var conn = connFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                string name = "TestQue";
                channel.QueueDeclare(name, false, false, false, null);
                string messageToQueue = "First test message to queue";

                byte[] byteMessage = System.Text.Encoding.UTF8.GetBytes(messageToQueue);
                channel.BasicPublish("", name, null, byteMessage);
                IBasicProperties props = channel.CreateBasicProperties();
                props.ContentType = "text/plain";
                props.DeliveryMode = 2;
                props.Expiration = "36000000";
                //channel.BasicPublish(name, "TestExchange", true, null, byteMessage);
                temp = true;
            }
            return temp;
        }
    }
}
