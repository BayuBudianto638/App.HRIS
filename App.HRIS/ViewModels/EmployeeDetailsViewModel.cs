using App.HRIS.Models;
using App.HRIS.Services.Employees;
using GalaSoft.MvvmLight;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.HRIS.ViewModels
{
    public class EmployeeDetailsViewModel : ViewModelBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeDetailsViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

            LoadEmployeeData();
        }

        public Employee Employee { get; set; }

        public async Task LoadEmployeeData()
        {
            try
            {
                int employeeId = 1;
                Employee = await _employeeService.GetEmployeeById(employeeId);
                OnPropertyChanged(nameof(Employee));
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error fetching employee data: {ex.Message}");
            }
        }
    }
}
