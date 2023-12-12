using Company.Logic.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Company.Logic.classes.Employees
{
    public class Developer : Employee
    {
        private int _id;
        private string _programmingLanguage;
        private int _salary;
        private string _firstName;
        private string _lastName;
        private Role _role;

        public Developer(string firstName, string lastName, int id, Role role, int salary, string department, string progLanguage)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Role = role;
            Salary = salary;
            Department = department;
            ProgrammingLanguage = progLanguage;
        }

        public override string FirstName
        {
            get => _firstName;
            set
            {
                if (IsValidName(value))
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentException("Invalid first name. Please use only Latin letters.");
                }
            }
        }

        public override string LastName
        {
            get => _lastName;
            set
            {
                if (IsValidName(value))
                {
                    _lastName = value;
                }
                else
                {
                    throw new ArgumentException("Invalid last name. Please use only Latin letters.");
                }
            }
        }

        public override int Id
        {
            get => _id;
            set => _id = value;
        }

        public override Role Role
        {
            get => _role;
            set
            {
                if (Enum.IsDefined(typeof(Role), value))
                {
                    _role = value;
                }
                else
                {
                    throw new ArgumentException("Invalid role. Please provide a valid Role value.");
                }
            }
        }

        public override int Salary
        {
            get => _salary;
            set
            {
                if (value >= 0)
                {
                    _salary = value;
                }
                else
                {
                    throw new ArgumentException("Invalid salary. Salary must be non-negative.");
                }
            }
        }

        public string Department { get; set; }

        public string ProgrammingLanguage
        {
            get => _programmingLanguage;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _programmingLanguage = value;
                }
                else
                {
                    throw new ArgumentException("Invalid programming language. Please provide a non-empty value.");
                }
            }
        }

        private bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, "^[a-zA-Z]+$");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Developer ID: {Id}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Role: {Role}");
            Console.WriteLine($"Salary: {Salary:C}");
            Console.WriteLine($"Programming Language: {ProgrammingLanguage}");
        }

        public override object Clone()
        {
            return MemberwiseClone();
        }

        public override void PromoteEmployee(Role newRole, int salaryIncrease, int bonusPercentage)
        {
            double bonus = CalculateBonus(bonusPercentage);

            Salary += salaryIncrease;
            Role = newRole;

            Console.WriteLine($"Promoted Developer to {newRole} with a salary increase of {salaryIncrease:C} and a bonus of {bonus:C}. Updated information:");
            DisplayInfo();
        }

        public override double CalculateBonus(int bonusPercentage)
        {
            double bonus = Salary * (bonusPercentage / 100.0);
            return bonus;
        }

        public override void PrintToConsole()
        {
            Console.WriteLine($"Printing Developer Info to Console:");
            DisplayInfo();
        }

        public override void PrintToFileTXT(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Developer ID: {Id}");
                writer.WriteLine($"Name: {FirstName} {LastName}");
                writer.WriteLine($"Role: {Role}");
                writer.WriteLine($"Salary: {Salary:C}");
                writer.WriteLine($"Programming Language: {ProgrammingLanguage}");
            }
            Console.WriteLine($"Developer Info has been printed to {filePath}");
        }
    }
}