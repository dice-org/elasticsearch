using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.ConnectionFactory;
using Domain.Converters;
using Domain.Entities;
using Domain.ViewModels;
using EasyNetQ.Topology;
using Nest;

namespace Domain.Supervisor
{
    public class EmployeeSupervisor : IEmployeeSupervisor
    {
        private readonly IElasticConnection _IElasticConnection;
        private readonly IElasticClient _IElasticClient;
        public EmployeeSupervisor(IElasticConnection elasticConnection, IElasticClient IElasticClient)
        {
            _IElasticConnection = elasticConnection;
            _IElasticClient = IElasticClient;
        }
        public EmployeeViewModel AddEmployee(EmployeeViewModel input, CancellationToken ct = default(CancellationToken))
        {
            using (var bus = _IElasticConnection.GetBus())
            {
                Console.WriteLine("Enter a message. 'Quit' to quit.");


                bus.Publish(new Employee
                {
                    id = (input.id > 0) ? input.id : 0,
                    firstName = input.firstName,
                    lastName = input.lastName

                });
                //  bus.Dispose();    
            }


            return input;
            // throw new NotImplementedException();
        }



        public object GetEmployees(CancellationToken ct = default(CancellationToken))
        {



            var response = _IElasticClient.Search<Employee>(
                s => s.MatchAll()).Documents;


            return response;



            //s.Query(q => q.QueryString(d => d.Query("spider"))));


            //  throw new NotImplementedException();
        }

        public string UpdateEmployee(int id, EmployeeViewModel input)
        {
            Employee emp = new Employee { firstName = input.firstName, lastName = input.lastName, id = input.id };
            var responseUpdate = _IElasticClient.
                Update(DocumentPath<Employee>
                .Id(id),
                u => u
               // .DocAsUpsert(true)
               .Doc(emp));

            return responseUpdate.Result.ToString();
        }


        public string DeleteEmployee(int id)
        {
            var result = _IElasticClient.Delete<Employee>(id);

            return result.Result.ToString();
        }

        public EmployeeViewModel GetEmployeeById(int id, CancellationToken ct = default(CancellationToken))
        {
            var response = _IElasticClient.Get<Employee>(id);
            
            EmployeeViewModel employee = EmplyoeeViewModelConverter.EmployeeConvert(response.Source);

            return employee;
        }
    }
}
