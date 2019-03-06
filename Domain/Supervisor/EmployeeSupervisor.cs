using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.ConnectionFactory;
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
                    //Id =input.Id,
                    FirstName = input.FirstName,
                    LastName = input.LastName

                });
                //  bus.Dispose();    
            }


            return input;
            // throw new NotImplementedException();
        }

        public object GetEmployees(CancellationToken ct = default(CancellationToken))
        {

            //var scanResults = client.Search<ClassName>(s => s
            //    .From(0)
            //    .Size(2000)
            //    .MatchAll()
            //    .Fields(f => f.Field(fi => fi.propertyName)) //I used field to get only the value I needed rather than getting the whole document
            //    .SearchType(Elasticsearch.Net.SearchType.Scan)
            //    .Scroll("5m")
            //);


            var response = _IElasticClient.Search<Employee>(
                s => s.MatchAll()).Documents;


            return response;



            //s.Query(q => q.QueryString(d => d.Query("spider"))));


            //  throw new NotImplementedException();
        }
    }
}
