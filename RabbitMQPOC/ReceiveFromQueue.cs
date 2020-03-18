using RabbitMQ.Client.Events;
using System;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQPOC
{
    public class ReceiveFromQueue
    {
        public void ReceiveDataFromQueue()
        {
            string message = "";
            byte[] body = null;
            var connFactory = new RabbitMQ.Client.ConnectionFactory() { HostName = "localhost" };
            using (var conn = connFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare("TestQue", false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (ch, ea) =>
                {
                    body = ea.Body;
                    // ... process the message

                    message = System.Text.Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                    //channel.BasicAck(ea.DeliveryTag, false);
                };
                String consumerTag = channel.BasicConsume("TestQue", true, consumer);
                Console.WriteLine("er r einsenheimmm");
            }
        }
    }
}
