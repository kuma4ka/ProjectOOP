using Company.Logic.classes;
using Company.Logic.enums;

namespace Test
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void TeamConstructor_InitializesProperties()
        {
            string teamName = "Development Team";
            int teamId = 1;

            Team team = new Team(teamName, teamId);

            Assert.AreEqual(teamName, team.TeamName);
            Assert.AreEqual(teamId.ToString(), team.TeamId);
            Assert.IsNotNull(team.TeamMembers);
            Assert.AreEqual(0, team.TeamMembers.Count);
        }

        [TestMethod]
        public void AddTeamMember_AddsMemberToList()
        {
            Team team = new Team("Development Team", 1);

            string name = "Test Name";
            int id = 1;
            Role role = Role.TeamLead;

            Employee employee = new(name, id, role);

            team.AddTeamMember(employee);

            Assert.IsTrue(team.TeamMembers.Contains(employee));
        }

        [TestMethod]
        public void RemoveTeamMember_RemovesMemberFromList()
        {
            Team team = new Team("Development Team", 1);

            string name = "Test Name";
            int id = 1;
            Role role = Role.TeamLead;

            Employee employee = new(name, id, role);

            team.AddTeamMember(employee);

            team.RemoveTeamMember(employee);

            Assert.IsFalse(team.TeamMembers.Contains(employee));
        }

        [TestMethod]
        public void DisplayTeamInfo_ReturnsFormattedInfo()
        {
            Team team = new Team("Development Team", 1);

            string name = "Test Name";
            int id = 1;
            Role role = Role.TeamLead;

            Employee employee = new(name, id, role);

            team.AddTeamMember(employee);

            string info = CaptureConsoleOutput(() => team.DisplayTeamInfo());

            Assert.IsTrue(info.Contains("Development Team"));
            Assert.IsTrue(info.Contains("John Doe"));
        }

        private string CaptureConsoleOutput(Action action)
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                action();

                return sw.ToString();
            }
        }
    }
}