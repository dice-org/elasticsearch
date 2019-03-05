using Domain.Entities;
using EasyNetQ;
using EasyNetQ.Topology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            PublishMessages();
        }
        static void PublishMessages()
        {
            string input = "";
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Enter a message. 'Quit' to quit.");

                while ((input = Console.ReadLine()) != "Quit")
                {

                  //  var exchange = bus.Advanced.ExchangeDeclare("elastic2", ExchangeType.Topic);
                  //  var queue = bus.Advanced.QueueDeclare("elastic_queue2");
                  //  bus.Advanced.Bind(exchange, queue, "#");

                    bus.Publish(new Employee
                    {
                        FirstName = input
                    });
                }
            }
        }


    }
}
