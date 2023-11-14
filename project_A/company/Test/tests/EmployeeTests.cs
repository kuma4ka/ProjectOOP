using Company.Logic.classes;
using Company.Logic.enums;

namespace Test
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void EmployeeConstructor_InitializesProperties()
        {
            string name = "John Doe";
            int id = 1;
            Role role = Role.Developer;

            Employee employee = new Employee(name, id, role);

            Assert.AreEqual(name, employee.FirstName);
            Assert.AreEqual(id, employee.Salary);
            Assert.AreEqual(role, employee.EmployeeRole);
        }

        [TestMethod]
        public void CalculateBonus_CalculatesBonusCorrectly()
        {
            Employee employee = new Employee("John Doe", 1, Role.Developer);
            int bonusPercentage = 10;

            double bonus = employee.CalculateBonus(bonusPercentage);

            Assert.AreEqual(0.1 * employee.Salary, bonus, 0.01);
        }

        [TestMethod]
        public void DisplayEmployeeInfo_ReturnsFormattedInfo()
        {
            Employee employee = new Employee("John Doe", 1, Role.Developer);

            string info = CaptureConsoleOutput(() => employee.DisplayEmployeeInfo());

            Assert.IsTrue(info.Contains("John Doe"));
            Assert.IsTrue(info.Contains("Developer"));
            Assert.IsTrue(info.Contains("Salary:"));
        }

        [TestMethod]
        public void PromoteEmployee_UpdatesRoleAndSalary()
        {
            Employee employee = new Employee("John Doe", 1, Role.Developer);
            Role newRole = Role.TeamLead;
            int salaryIncrease = 5000;

            employee.PromoteEmployee(newRole, salaryIncrease);

            Assert.AreEqual(newRole, employee.EmployeeRole);
            Assert.AreEqual(1 + salaryIncrease, employee.Salary);
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