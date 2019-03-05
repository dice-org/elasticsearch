using Domain.Entities;
using EasyNetQ;
using EasyNetQ.Management.Client;
using EasyNetQ.Management.Client.Model;
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
        static   void Subscribe()
        {
            //Console.WriteLine("Enter 1 to publish , 2 to Subscribe ");

            using (var subbus = RabbitHutch.CreateBus("host=localhost"))
            {
                subbus.Subscribe<Employee>("test", HandleTextMessage);

                //var managementClient = new ManagementClient("http://localhost", "guest", "guest");
                ////var queues = await managementClient.GetQueuesAsync();
                ////foreach (var queue in queues)
                ////{
                ////    Console.Out.WriteLine("queue.Name = {0}", queue.Name);

                ////}
                //var vhost = await managementClient.GetVhostAsync("/");

                //var queue =  await managementClient.GetQueueAsync("elastic_queue2", vhost);
                //   Console.Out.WriteLine("queue.Name = {0}", queue.Name);

                //var bindings = managementClient.GetBindingsForQueueAsync(queue);

                //// subbus.Advanced.QueuePurge(queue);
                ////  Message message = new Message { MessageDescription = "test" };
                ////  Insert(message);
                //Ackmodes ackmodes = new Ackmodes();
                //var criteria = new GetMessagesCriteria(1,ackmodes);

                //var messages = await managementClient.GetMessagesFromQueueAsync(queue, criteria);

                //foreach (var message in messages)
                //{
                //    Console.Out.WriteLine("message = {0}", message);
                //}

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();

            }
        }


            static void HandleTextMessage(Employee employee)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Got message: {0}", employee.FirstName);
                Console.ResetColor();

            }



        }


    
}
