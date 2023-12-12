using Company.Logic.classes;
using Company.Logic.classes.Employees;
using Company.Logic.enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Test
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void TeamConstructor_InitializesProperties()
        {
            string teamName = "Dev";
            string teamId = "1";

            Team team = new Team(teamName, teamId);

            Assert.AreEqual(teamName, team.TeamName);
            Assert.AreEqual(teamId, team.TeamId);
        }

        [TestMethod]
        public void AddTeamMember_AddsMemberToList()
        {
            Team team = new Team("Dev1", "1");

            string firstName = "Test";
            string lastName = "Test";
            int id = 1;
            Role role = Role.Manager;
            int salary = 1200;
            string department = "Department";

            Manager employee = new Manager(firstName, lastName, id, role, salary, department);
            team.AddTeamMember(employee);

            Assert.IsTrue(team.TeamMembers.Contains(employee));
        }

        [TestMethod]
        public void RemoveTeamMember_RemovesMemberFromList()
        {
            Team team = new Team("Dev1", "1");

            string firstName = "Test";
            string lastName = "Test";
            int id = 1;
            Role role = Role.Manager;
            int salary = 1200;
            string department = "Department";

            Manager employee = new Manager(firstName, lastName, id, role, salary, department);
            team.AddTeamMember(employee);

            team.RemoveTeamMember(employee);

            Assert.IsFalse(team.TeamMembers.Contains(employee));
        }
    }
}