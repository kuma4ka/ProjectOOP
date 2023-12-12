using Company.Logic.classes;
using Company.Logic.classes.Employees;
using Company.Logic.enums;
using Company.Logic.services;

namespace Company.Interface.Interface
{
    public class Menu
    {
        private Department department = null;
        private static int nextEmployeeId = 1;

        public void ShowMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("Company Management System");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Add Team");
                Console.WriteLine("3. Add Employee");
                Console.WriteLine("4. Display Department Information");
                Console.WriteLine("5. Promote Employee");
                Console.WriteLine("6. Change Department Name");
                Console.WriteLine("7. Remove Team Member");
                Console.WriteLine("0. Exit");
                Console.WriteLine("-------------------------");

                Console.Write("Enter your choice (0-5): ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    try
                    {
                        ProcessChoice(choice);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            } while (choice != 0);
        }

        private void ProcessChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddDepartment();
                    break;

                case 2:
                    AddTeam();
                    break;

                case 3:
                    AddEmployee();
                    break;

                case 4:
                    DisplayDepartmentInfo();
                    break;

                case 5:
                    PromoteEmployee();
                    break;

                case 6:
                    ChangeDepartmentName();
                    break;

                case 7:
                    RemoveTeamMember();
                    break;

                case 0:
                    Console.WriteLine("Exiting the application. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 0 and 5.");
                    break;
            }
        }

        private void AddDepartment()
        {
            try
            {
                if (department == null)
                {
                    Console.Write("Enter the department name: ");
                    string departmentName = Console.ReadLine();
                    department = new Department(departmentName);

                    department.PerformActionWithDepartmentName(name => NotificationManager.ShowGreenNotification($"Department '{name}' added successfully."));
                }
                else
                {
                    NotificationManager.ShowRedNotification("A department already exists. Only one department is allowed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void AddTeam()
        {
            try
            {
                if (department != null)
                {
                    Console.Write("Enter the team name: ");
                    string teamName = Console.ReadLine();

                    department.AddTeam(new Team(teamName, GenerateTeamId()));
                }
                else
                {
                    throw new InvalidOperationException("No department available. Please create a department first.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void AddEmployee()
        {
            try
            {
                Team selectedTeam = null;
                Console.WriteLine("Select a team:");
                for (int i = 0; i < department.Teams.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {department.Teams[i].TeamName}");
                }

                Console.Write("Enter the team number to add the employee: ");
                if (int.TryParse(Console.ReadLine(), out int teamNumber) && teamNumber > 0 && teamNumber <= department.Teams.Count)
                {
                    selectedTeam = department.Teams[teamNumber - 1];
                    Console.WriteLine($"Employee will be added to the team {selectedTeam.TeamName}");
                }
                else
                {
                    Console.WriteLine("Invalid team number. Please enter a valid team number.");
                }

                Console.Write("Enter the employee's first name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter the employee's last name: ");
                string lastName = Console.ReadLine();

                Console.Write("Enter the employee's salary: ");
                if (int.TryParse(Console.ReadLine(), out int salary))
                {
                }
                else
                {
                    throw new ArgumentException("Invalid salary input. Please enter a valid number.");
                }

                Console.WriteLine("Select the employee's role:");
                Console.WriteLine("1. Manager");
                Console.WriteLine("2. Developer");
                Console.Write("Enter the role number: ");

                if (int.TryParse(Console.ReadLine(), out int roleChoice))
                {
                    Role role;

                    switch (roleChoice)
                    {
                        case 1:
                            role = Role.Manager;
                            Manager manager = new(firstName, lastName, nextEmployeeId++, role, salary, department.DepartmentName);
                            Console.WriteLine("Added employee info:");
                            selectedTeam.AddTeamMember(manager);
                            department.AddEmployee(manager);
                            break;

                        case 2:
                            role = Role.Developer;
                            Console.Write("Enter the programming language for the developer: ");
                            string programmingLanguage = Console.ReadLine();
                            Developer developer = new Developer(firstName, lastName, nextEmployeeId++, role, salary, department.DepartmentName, programmingLanguage);
                            selectedTeam.AddTeamMember(developer);
                            department.AddEmployee(developer);
                            break;

                        default:
                            throw new ArgumentException("Invalid role choice. Please enter a valid role number.");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid role choice. Please enter a valid role number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void RemoveTeamMember()
        {
            try
            {
                if (department != null && department.Teams.Count > 0)
                {
                    Console.WriteLine("Select a team:");
                    for (int i = 0; i < department.Teams.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {department.Teams[i].TeamName}");
                    }

                    Console.Write("Enter the team number to select the team for removing an employee: ");
                    if (int.TryParse(Console.ReadLine(), out int teamNumber) && teamNumber > 0 && teamNumber <= department.Teams.Count)
                    {
                        Team selectedTeam = department.Teams[teamNumber - 1];
                        Console.WriteLine($"Select an employee from the team {selectedTeam.TeamName} to remove:");

                        if (selectedTeam.TeamMembers.Count > 0)
                        {
                            for (int i = 0; i < selectedTeam.TeamMembers.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {selectedTeam.TeamMembers[i].FirstName} {selectedTeam.TeamMembers[i].LastName}");
                            }

                            Console.Write("Enter the employee number to remove: ");
                            if (int.TryParse(Console.ReadLine(), out int employeeNumber) && employeeNumber > 0 && employeeNumber <= selectedTeam.TeamMembers.Count)
                            {
                                Employee selectedEmployee = selectedTeam.TeamMembers[employeeNumber - 1];

                                selectedTeam.TeamMemberRemoved += HandleTeamMemberRemoved;

                                selectedTeam.RemoveTeamMember(selectedEmployee);

                                selectedTeam.TeamMemberRemoved -= HandleTeamMemberRemoved;
                            }
                            else
                            {
                                throw new ArgumentException("Invalid employee number. Please enter a valid employee number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No employees in the selected team.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid team number. Please enter a valid team number.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("No department or teams available. Please create a department and teams first.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void DisplayDepartmentInfo()
        {
            try
            {
                department.DisplayDepartmentInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void PromoteEmployee()
        {
            try
            {
                if (department != null && department.Teams.Count > 0)
                {
                    Console.WriteLine("Select a team:");
                    for (int i = 0; i < department.Teams.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {department.Teams[i].TeamName}");
                    }

                    Console.Write("Enter the team number to select the employee for promotion: ");
                    if (int.TryParse(Console.ReadLine(), out int teamNumber) && teamNumber > 0 && teamNumber <= department.Teams.Count)
                    {
                        Team selectedTeam = department.Teams[teamNumber - 1];
                        Console.WriteLine($"Select an employee from the team {selectedTeam.TeamName} for promotion:");

                        if (selectedTeam.TeamMembers.Count > 0)
                        {
                            for (int i = 0; i < selectedTeam.TeamMembers.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {selectedTeam.TeamMembers[i].FirstName} {selectedTeam.TeamMembers[i].LastName}");
                            }

                            Console.Write("Enter the employee number to promote: ");
                            if (int.TryParse(Console.ReadLine(), out int employeeNumber) && employeeNumber > 0 && employeeNumber <= selectedTeam.TeamMembers.Count)
                            {
                                Employee selectedEmployee = selectedTeam.TeamMembers[employeeNumber - 1];

                                Console.WriteLine($"Select the new role for {selectedEmployee.FirstName} {selectedEmployee.LastName}:");
                                Console.WriteLine("1. Manager");
                                Console.WriteLine("2. Developer");
                                Console.Write("Enter the role number: ");

                                if (int.TryParse(Console.ReadLine(), out int newRoleChoice))
                                {
                                    Role newRole;

                                    switch (newRoleChoice)
                                    {
                                        case 1:
                                            newRole = Role.Manager;
                                            break;

                                        case 2:
                                            newRole = Role.Developer;
                                            break;

                                        default:
                                            throw new ArgumentException("Invalid role choice. Please enter a valid role number.");
                                    }

                                    Console.Write("Enter the salary increase for the promotion: ");
                                    if (int.TryParse(Console.ReadLine(), out int salaryIncrease))
                                    {
                                        Console.Write("Enter the bonus percentage for the promotion: ");
                                        if (int.TryParse(Console.ReadLine(), out int bonusPercentage))
                                        {
                                            selectedEmployee.PromoteEmployee(newRole, salaryIncrease, bonusPercentage);
                                        }
                                        else
                                        {
                                            throw new ArgumentException("Invalid bonus percentage. Please enter a valid number.");
                                        }
                                    }
                                    else
                                    {
                                        throw new ArgumentException("Invalid salary increase. Please enter a valid number.");
                                    }
                                }
                                else
                                {
                                    throw new ArgumentException("Invalid role choice. Please enter a valid role number.");
                                }
                            }
                            else
                            {
                                throw new ArgumentException("Invalid employee number. Please enter a valid employee number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No employees in the selected team.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid team number. Please enter a valid team number.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("No department or teams available. Please create a department and teams first.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void ChangeDepartmentName()
        {
            try
            {
                if (department != null)
                {
                    Console.Write("Enter the new department name: ");
                    string newDepartmentName = Console.ReadLine();

                    bool departmentExists = department.CheckDepartmentName(existingDepartmentName =>
                    {
                        return existingDepartmentName == newDepartmentName;
                    });

                    if (departmentExists)
                    {
                        NotificationManager.ShowRedNotification(
                            $"The department with the name '{newDepartmentName}' already exists.");
                    }
                    else
                    {
                        department.PerformActionWithDepartmentName(oldDepartmentName =>
                        {
                            Console.WriteLine($"Changing department name from '{oldDepartmentName}' to '{newDepartmentName}'");
                            department.DepartmentName = newDepartmentName;
                            department.PerformActionWithDepartmentName(name => Console.WriteLine($"Department name was changed from {oldDepartmentName} to '{name}' successfully."));
                        });
                    }
                }
                else
                {
                    NotificationManager.ShowRedNotification("No department available. Please create a department first.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void HandleTeamMemberRemoved(object sender, TeamMemberUpdate e)
        {
            NotificationManager.ShowGreenNotification($"{e.UpdatedMember.FirstName} {e.UpdatedMember.LastName} was removed from the team.");
        }

        private string GenerateTeamId()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string randomPart = Guid.NewGuid().ToString("N").Substring(0, 4);

            return $"{timestamp}-{randomPart}";
        }
    }
}