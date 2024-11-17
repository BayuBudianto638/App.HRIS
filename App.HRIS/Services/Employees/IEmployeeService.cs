using App.HRIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.HRIS.Services.Employees
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeById(int employeeId);
    }
}
