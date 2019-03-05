using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.ConnectionFactory;
using Domain.Entities;
using Domain.ViewModels;
using EasyNetQ.Topology;

namespace Domain.Supervisor
{
  public  class EmployeeSupervisor : IEmployeeSupervisor
    {
        private readonly IElasticConnection _IElasticConnection;
        
        public EmployeeSupervisor(IElasticConnection elasticConnection)
        {
            _IElasticConnection = elasticConnection;
        }
        public EmployeeViewModel AddEmployee(EmployeeViewModel input, CancellationToken ct = default(CancellationToken))
        {
            using (var bus = _IElasticConnection.GetBus())
            {
                Console.WriteLine("Enter a message. 'Quit' to quit.");


                bus.Publish(new Employee
                {
                    //Id =input.Id,
                    FirstName = input.FirstName,
                    LastName = input.LastName

                });
              //  bus.Dispose();    
            }

            
            return input;
           // throw new NotImplementedException();
        }

        public Task<List<EmployeeViewModel>> GetEmployees(CancellationToken ct = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
