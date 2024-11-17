using App.HRIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.HRIS.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            await Task.Delay(1000); 

            return new Employee
            {
                Id = 1,
                NIK = "EMP001",
                Name = "John Doe",
                Position = "Software Engineer",
                EmployeeImage = ImageSource.FromFile("employee_image.png"),
                AttendanceDetails = new List<AttendanceDetail>
            {
                new AttendanceDetail { 
                    Date = new DateTime(2023, 11, 1), TimeIn = new TimeSpan(9, 0, 0), TimeOut = new TimeSpan(17, 0, 0) 
                },               
            }};
        }
    }
}
