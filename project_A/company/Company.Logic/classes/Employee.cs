using Company.Logic.enums;
using Company.Logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Logic.classes
{
    public abstract class Employee : ICloneable, IPrintable
    {
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract int Id { get; set; }
        public abstract Role Role { get; set; }
        public abstract int Salary { get; set; }

        public abstract double CalculateBonus(int bonusPercentage);

        public abstract void DisplayInfo();

        public abstract object Clone();

        public abstract void PromoteEmployee(Role newRole, int salaryIncrease, int bonusPercentage);

        public abstract void PrintToConsole();

        public abstract void PrintToFileTXT(string filePath);
    }
}