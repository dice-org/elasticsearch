using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEmployeeRepositorie
    {
        List<Employee> GetEmployees(CancellationToken ct = default(CancellationToken));
        Employee AddEmpoyee(Employee employee, CancellationToken ct = default(CancellationToken));
        Employee  GetEmployeeById( int id,CancellationToken ct = default(CancellationToken));

    }
}
