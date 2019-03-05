using Domain.Entities;
using EasyNetQ;
using EasyNetQ.Management.Client;
using EasyNetQ.Management.Client.Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            Subscribe();
        }
        static void Subscribe()
        {
            //Console.WriteLine("Enter 1 to publish , 2 to Subscribe ");

            using (var subbus = RabbitHutch.CreateBus("host=localhost"))
            {
                subbus.Subscribe<Employee>("test", HandleTextMessage);
                //  subbus.Subscribe<Message>("test", HandleTextMessage);

               

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();

            }
        }

        static void AddToElastic( Employee employee)
        {
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
          
            var response = client.Index(employee, idx => idx.Index("employeesindex")); //or specify index via settings.DefaultIndex("mytweetindex");
        }

        static void HandleTextMessage(Employee employee)
        {
            AddToElastic(employee);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", employee.FirstName);
            Console.WriteLine("Got message: {0}", employee.LastName);
          //  Console.WriteLine("Got message: {0}", employee.Id);

            Console.ResetColor();

        }





    }



}
