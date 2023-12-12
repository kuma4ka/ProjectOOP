using Company.Logic.classes.Employees;
using Company.Logic.interfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Company.Logic.services;

namespace Company.Logic.classes
{
    public class Team : ITeam
    {
        public event EventHandler<TeamMemberUpdate> TeamMemberAdd;

        public event EventHandler<TeamMemberUpdate> TeamMemberRemoved;

        private string _teamName;
        private string _teamDescription;
        private string _teamId;
        private List<Employee> _teamMembers = new List<Employee>();

        public string TeamName
        {
            get => _teamName;
            set
            {
                if (IsValidTeamName(value))
                {
                    _teamName = value;
                }
                else
                {
                    throw new ArgumentException("Invalid team name. TeamName should contain only Latin letters and digits, and should not exceed 10 characters.");
                }
            }
        }

        public string TeamDescription
        {
            get => _teamDescription;
            set
            {
                if (IsValidDescription(value))
                {
                    _teamDescription = value;
                }
                else
                {
                    throw new ArgumentException("Invalid team description. TeamDescription should not exceed 30 characters.");
                }
            }
        }

        public string TeamId
        {
            get => _teamId;
            set
            {
                if (IsValidId(value))
                {
                    _teamId = value;
                }
                else
                {
                    throw new ArgumentException("Invalid team ID.");
                }
            }
        }

        public List<Employee> TeamMembers
        {
            get => _teamMembers;
            private set => _teamMembers = value;
        }

        public Team(string teamName, string teamId)
        {
            TeamName = teamName;
            TeamId = teamId;
        }

        public void AddTeamMember(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");
            }

            if (TeamMembers.Contains(employee))
            {
                NotificationManager.ShowRedNotification($"{employee.FirstName} {employee.LastName} is already a member of the team {TeamName}.");
            }
            else
            {
                TeamMembers.Add(employee);
                TeamMemberAdd?.Invoke(this, new TeamMemberUpdate(employee));
            }
        }

        public void DisplayTeamInfo()
        {
            Console.WriteLine($"Team Information for Team {TeamName} (ID: {TeamId}):");
            Console.WriteLine($"Description: {TeamDescription}");
            Console.WriteLine("Team Members:");

            foreach (var member in TeamMembers)
            {
                Console.WriteLine($"- {member.FirstName} {member.LastName}");
            }
        }

        public void DisplayEmployeeInfo(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");
            }

            Console.WriteLine($"- {employee.FirstName} {employee.LastName}, ID: {employee.Id}, Role: {employee.Role}, Salary: {employee.Salary:C}");
        }

        public void RemoveTeamMember(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");
            }

            if (TeamMembers.Contains(employee))
            {
                TeamMembers.Remove(employee);
                OnTeamMemberRemoved(employee);
            }
            else
            {
                NotificationManager.ShowRedNotification($"{employee.FirstName} {employee.LastName} is not a member of the team {TeamName}.");
            }
        }

        protected virtual void OnTeamMemberRemoved(Employee removedMember)
        {
            TeamMemberRemoved?.Invoke(this, new TeamMemberUpdate(removedMember));
        }

        private bool IsValidTeamName(string teamName)
        {
            return !string.IsNullOrWhiteSpace(teamName) && Regex.IsMatch(teamName, "^[a-zA-Z0-9]{1,10}$");
        }

        private bool IsValidDescription(string teamDescription)
        {
            return teamDescription?.Length <= 30;
        }

        private bool IsValidId(string teamId)
        {
            return !string.IsNullOrEmpty(teamId);
        }
    }
}