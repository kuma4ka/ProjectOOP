using Microsoft.VisualStudio.TestTools.UnitTesting;
using Company.Logic.classes.Employees;
using Company.Logic.enums;
using Company.Logic.interfaces;
using System;
using System.IO;
using Company.Logic.classes;

namespace Test
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void EmployeeConstructor_InitializesProperties()
        {
            string firstName = "John";
            string lastName = "Doe";
            int id = 1;
            Role role = Role.Developer;
            int salary = 50000;

            Manager employee = new Manager(firstName, lastName, id, role, salary, "Test Department");

            Assert.AreEqual(firstName, employee.FirstName);
            Assert.AreEqual(lastName, employee.LastName);
            Assert.AreEqual(id, employee.Id);
            Assert.AreEqual(role, employee.Role);
            Assert.AreEqual(salary, employee.Salary);
        }

        [TestMethod]
        public void CalculateBonus_CalculatesBonusCorrectly()
        {
            string firstName = "John";
            string lastName = "Doe";
            int id = 1;
            Role role = Role.Developer;
            int salary = 50000;

            Manager employee = new Manager(firstName, lastName, id, role, salary, "Test Department");
            int bonusPercentage = 10;

            double bonus = employee.CalculateBonus(bonusPercentage);

            Assert.AreEqual(0.1 * salary, bonus, 0.01);
        }

        [TestMethod]
        public void PromoteEmployee_UpdatesRoleAndSalary()
        {
            string firstName = "John";
            string lastName = "Doe";
            int id = 1;
            Role role = Role.Developer;
            int salary = 50000;

            Manager employee = new Manager(firstName, lastName, id, role, salary, "Test Department");
            Role newRole = Role.TeamLead;
            int salaryIncrease = 5000;
            int bonusPercentage = 15;

            employee.PromoteEmployee(newRole, salaryIncrease, bonusPercentage);

            Assert.AreEqual(newRole, employee.Role);
            Assert.AreEqual(salary + salaryIncrease, employee.Salary);
        }
    }
}