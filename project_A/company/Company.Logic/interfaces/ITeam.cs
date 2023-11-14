using Company.Logic.classes;

namespace Company.Logic.interfaces
{
    public interface ITeam
    {
        string TeamName { get; set; }
        string TeamDescription { get; set; }
        string TeamId { get; set; }
        List<Employee> TeamMembers { get; }

        void AddTeamMember(Employee employee);

        void RemoveTeamMember(Employee employee);

        void DisplayTeamInfo();
    }
}