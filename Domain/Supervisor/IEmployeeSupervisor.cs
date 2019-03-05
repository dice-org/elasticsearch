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
        Task<EmployeeViewModel> AddEmployee(EmployeeViewModel input, CancellationToken ct = default(CancellationToken));


        Task<List<EmployeeViewModel>> GetEmployees(CancellationToken ct = default(CancellationToken));
    }
}
