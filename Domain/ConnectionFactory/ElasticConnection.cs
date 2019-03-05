using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ConnectionFactory
{
    public class ElasticConnection:IElasticConnection
    {
        public IBus bus;

        public ElasticConnection()
        {
            this.bus = RabbitHutch.CreateBus("host=localhost");
        }
        public IBus GetBus()
        {
            return bus;
        }
    }
}
