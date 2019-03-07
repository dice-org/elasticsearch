using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Converters
{
   public  static class EmplyoeeViewModelConverter
    {
        public static EmployeeViewModel EmployeeConvert(Employee employee)
        {
            var employeeViewModel = new EmployeeViewModel();
            employeeViewModel.firstName = employee.firstName;
            employeeViewModel.id = employee.id;
            employeeViewModel.lastName = employee.lastName;

           

            return employeeViewModel;
        }

    }
}
