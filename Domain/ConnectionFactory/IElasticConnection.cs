using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ConnectionFactory
{
    public interface IElasticConnection
    {
        IBus GetBus();
    }
}
