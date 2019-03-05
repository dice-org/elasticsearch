using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EmployeeRepositorie : IEmployeeRepositorie
    {
        private readonly  List<Employee> Employees = new List<Employee>();

        public EmployeeRepositorie()
        {
            Employees.Add(new Employee
            {
             //   Id = 1,
                FirstName = "Spider",
                LastName = "Man",
            });
            Employees.Add(new Employee
            {
             //   Id = 2,
                FirstName = "Bat",
                LastName = "Man",
            });
            Employees.Add(new Employee
            {
              //  Id = 3,
                FirstName = "Captin",
                LastName = "America",
            });

        }

        public Employee AddEmpoyee(Employee employee, CancellationToken ct = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int id, CancellationToken ct = default(CancellationToken))
        {
            throw new NotImplementedException();

          //  return Employees.FirstOrDefault(c => c.Id == id);
        }

        public List<Employee> GetEmployees(CancellationToken ct = default(CancellationToken))
        {
            return Employees;
        }


    }
}
