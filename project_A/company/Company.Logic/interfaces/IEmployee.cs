using Company.Logic.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Logic.interfaces
{
    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Salary { get; set; }
        Role EmployeeRole { get; set; }

        void DisplayEmployeeInfo();

        double CalculateBonus(int bonusPercentage);

        void PromoteEmployee(Role newRole, int salaryIncrease);
    }
}