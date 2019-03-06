using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Supervisor
{
    public interface IEmployeeSupervisor
    {
        EmployeeViewModel AddEmployee(EmployeeViewModel input, CancellationToken ct = default(CancellationToken));


        object GetEmployees(CancellationToken ct = default(CancellationToken));
    }
}
