using Company.Logic.classes;
using Company.Logic.classes.Employees;

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

        void DisplayEmployeeInfo(Employee employee);
    }
}