using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Logic.classes
{
    public class Department
    {
        public Department(string departmentName)
        {
            throw new NotImplementedException();
        }

        public string? DepartmentName { get; set; }
        public List<Team> Teams { get; set; }
        public List<Employee> Employees { get; set; }

        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void AddTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void DisplayDepartmentInfo()
        {
            throw new NotImplementedException();
        }
    }
}