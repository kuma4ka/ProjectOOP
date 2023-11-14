using Company.Logic.enums;
using Company.Logic.interfaces;

namespace Company.Logic.classes
{
    public class Employee : IEmployee
    {
        public Employee(string name, int id, Role role)
        {
            throw new NotImplementedException();
        }

        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Salary { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Role EmployeeRole { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double CalculateBonus(int bonusPercentage)
        {
            throw new NotImplementedException();
        }

        public void DisplayEmployeeInfo()
        {
            throw new NotImplementedException();
        }

        public void PromoteEmployee(Role newRole, int salaryIncrease)
        {
            throw new NotImplementedException();
        }
    }
}