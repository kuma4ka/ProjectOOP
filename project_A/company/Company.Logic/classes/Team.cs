using Company.Logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Logic.classes
{
    public class Team : ITeam
    {
        public Team(string teamName, int teamId)
        {
            throw new NotImplementedException();
        }

        public string TeamName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TeamDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TeamId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<Employee> TeamMembers => throw new NotImplementedException();

        public void AddTeamMember(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DisplayTeamInfo()
        {
            throw new NotImplementedException();
        }

        public void RemoveTeamMember(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}