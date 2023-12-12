using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Company.Logic.classes.Employees;
using Company.Logic.delegates;
using Company.Logic.interfaces;
using Company.Logic.services;

namespace Company.Logic.classes
{
    public class Department
    {
        private string? _departmentName;

        public Department(string departmentName)
        {
            DepartmentName = departmentName;
            Teams = new List<Team>();
            Employees = new List<Employee>();
            DepartmentMessageHandler = DefaultMessageHandler;
        }

        public string? DepartmentName
        {
            get => _departmentName;
            set
            {
                if (IsValidDepartmentName(value))
                {
                    _departmentName = value;
                }
                else
                {
                    throw new ArgumentException("Invalid department name. DepartmentName should contain only Latin letters and digits, and should not exceed 10 characters.");
                }
            }
        }

        public List<Employee> Employees { get; set; }

        public List<Team> Teams { get; set; }

        public MessageHandlerDelegate DepartmentMessageHandler { get; set; }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void AddTeam(Team team)
        {
            Teams.Add(team);
            HandleTeamMemberUpdate(team);
            NotificationManager.ShowGreenNotification($"Team {team.TeamName} was added to the department {DepartmentName}.");
        }

        public void DisplayDepartmentInfo()
        {
            if (Teams.Count == 0)
            {
                NotificationManager.ShowRedNotification("The department has no teams or employees.");
                return;
            }

            DepartmentMessageHandler?.Invoke($"Department Information for {DepartmentName}:");

            DepartmentMessageHandler?.Invoke("Teams:");
            foreach (var team in Teams)
            {
                DepartmentMessageHandler?.Invoke($"- {team.TeamName}");
            }

            if (Employees.Count > 0)
            {
                DepartmentMessageHandler?.Invoke("Employees:");
                foreach (var employee in Employees)
                {
                    DepartmentMessageHandler?.Invoke($"- {employee.FirstName} {employee.LastName}");
                }
            }
            else
            {
                DepartmentMessageHandler?.Invoke("No employees in the department.");
            }
        }

        public void PerformActionWithDepartmentName(Action<string> action)
        {
            action?.Invoke(DepartmentName);
        }

        public bool CheckDepartmentName(Predicate<string> predicate)
        {
            return predicate?.Invoke(DepartmentName) ?? false;
        }

        private void DefaultMessageHandler(string message)
        {
            Console.WriteLine(message);
        }

        private void HandleTeamMemberUpdate(Team team)
        {
            team.TeamMemberAdd += (sender, e) =>
            {
                NotificationManager.ShowGreenNotification($"New team member added to Team {team.TeamName}: {e.UpdatedMember.FirstName} {e.UpdatedMember.LastName}");
            };
        }

        private bool IsValidDepartmentName(string? departmentName)
        {
            return !string.IsNullOrWhiteSpace(departmentName) && Regex.IsMatch(departmentName, "^[a-zA-Z0-9]{1,10}$");
        }
    }
}