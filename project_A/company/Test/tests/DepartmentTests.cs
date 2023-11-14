using Company.Logic.classes;
using Company.Logic.enums;

namespace Test
{
    [TestClass]
    public class DepartmentTests
    {
        [TestMethod]
        public void DepartmentConstructor_InitializesProperties()
        {
            string departmentName = "Test Department";

            Department department = new(departmentName);

            Assert.AreEqual(departmentName, department.DepartmentName);
            Assert.IsNotNull(department.Teams);
            Assert.IsNotNull(department.Employees);
        }

        [TestMethod]
        public void AddEmployee_AddsEmployeeToList()
        {
            Department department = new Department("Test Department");

            string name = "Test Name";
            int id = 1;
            Role role = Role.TeamLead;

            Employee employee = new(name, id, role);

            department.AddEmployee(employee);

            Assert.IsTrue(department.Employees.Contains(employee));
        }

        [TestMethod]
        public void AddTeam_AddsTeamToList()
        {
            Department department = new Department("Test Department");

            string teamName = "Test Name";
            int teamId = 1;

            Team team = new(teamName, teamId);

            department.AddTeam(team);

            Assert.IsTrue(department.Teams.Contains(team));
        }

        [TestMethod]
        public void DisplayDepartmentInfo_ReturnsFormattedInfo()
        {
            Department department = new Department("Test Department");

            string teamName = "Test Name";
            int teamId = 1;

            Team team = new(teamName, teamId);

            string name = "Test Name";
            int id = 1;
            Role role = Role.TeamLead;

            Employee employee = new(name, id, role);

            department.AddTeam(team);
            department.AddEmployee(employee);

            string info = CaptureConsoleOutput(() => department.DisplayDepartmentInfo());
            Assert.IsTrue(info.Contains("Test Department"));
            Assert.IsTrue(info.Contains("Development Team"));
            Assert.IsTrue(info.Contains("John Doe"));
        }

        private string CaptureConsoleOutput(Action value)
        {
            throw new NotImplementedException();
        }
    }
}