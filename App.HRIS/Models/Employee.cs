using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.HRIS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string NIK { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public ImageSource EmployeeImage { get; set; }
        public List<AttendanceDetail> AttendanceDetails { get; set; }
    }
}
