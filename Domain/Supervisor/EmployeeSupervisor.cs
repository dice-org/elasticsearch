using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.ConnectionFactory;
using Domain.Entities;
using Domain.ViewModels;

namespace Domain.Supervisor
{
  public  class EmployeeSupervisor : IEmployeeSupervisor
    {
        private readonly IElasticConnection _IElasticConnection;
        
        public EmployeeSupervisor(IElasticConnection elasticConnection)
        {
            _IElasticConnection = elasticConnection;
        }
        public Task<EmployeeViewModel> AddEmployee(EmployeeViewModel input, CancellationToken ct = default(CancellationToken))
        {
            using (var bus = _IElasticConnection.GetBus())
            {
                Console.WriteLine("Enter a message. 'Quit' to quit.");




               // var exchange = bus.Advanced.ExchangeDeclare("elastic2", ExchangeType.Topic);
                //var queue = bus.Advanced.QueueDeclare("elastic_queue2");
             //   bus.Advanced.Bind(exchange, queue, "#");

                bus.Publish(new Employee
                    {
                        FirstName = input.FirstName,
                        LastName=input.LastName
                        
                    });
                
            }


            throw new NotImplementedException();
        }

        public Task<List<EmployeeViewModel>> GetEmployees(CancellationToken ct = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
