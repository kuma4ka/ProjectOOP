using Company.Logic.classes;
using Company.Logic.classes.Employees;
using Company.Logic.enums;
using Company.Logic.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Test
{
    [TestClass]
    public class DepartmentTests
    {
        [TestMethod]
        public void DepartmentConstructor_InitializesProperties()
        {
            string departmentName = "Department";

            Department department = new Department(departmentName);

            Assert.AreEqual(departmentName, department.DepartmentName);
        }

        [TestMethod]
        public void AddEmployee_AddsEmployeeToList()
        {
            Department department = new Department("Department");

            string firstName = "John";
            string lastName = "Doe";
            int id = 1;
            Role role = Role.Manager;
            int salary = 5000;
            string departmentName = "Department";

            Manager employee = new Manager(firstName, lastName, id, role, salary, departmentName);

            department.AddEmployee(employee);

            Assert.IsTrue(department.Employees.Contains(employee));
        }

        [TestMethod]
        public void AddTeam_AddsTeamToList()
        {
            Department department = new Department("Department");

            department.DepartmentMessageHandler = CustomMessageHandler;

            string teamName = "Dev1";
            string teamId = "1";

            Team team = new Team(teamName, teamId);

            department.AddTeam(team);

            Assert.AreEqual($"Team Team was added to the department Department.", CustomNotificationMessage);
            Assert.IsTrue(department.Teams.Contains(team));
        }

        private string CustomNotificationMessage = "Team Team was added to the department Department.";

        private void CustomMessageHandler(string message)
        {
            CustomNotificationMessage = message;
        }
    }
}