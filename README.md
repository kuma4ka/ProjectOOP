# Company Management System
This project represents a simple Company Management System, designed to model the structure of a company with departments, teams, and employees.

## Features
**Company Class:** Represents the overall company and contains lists of employees, projects, and departments.
**Department Class:** Represents a department within the company, including teams and employees.
**Team Class:** Represents a team within a department, containing team members.
**Employee Class:** Represents an employee with personal information and roles within the company.

## Getting Started
To get started with the Company Management System, follow these steps:

- Clone the repository to your local machine.
- Open the solution in your preferred C# development environment (Visual Studio, Rider, etc.).
- Build the solution to ensure all dependencies are resolved.

## Usage
You can use the provided classes to model your own company structure in a C# application. Instantiate objects of the Company, Department, Team, and Employee classes, and utilize their properties and methods to manage your company's hierarchy.


## Example Usage

``Company myCompany = new Company();``
``Department engineeringDept = new Department("Engineering");``
``Team developmentTeam = new Team("Development", 1);``
``Employee johnDoe = new Employee("John", "Doe", 75000, Role.Developer);``

``engineeringDept.AddTeam(developmentTeam);``
``developmentTeam.AddTeamMember(johnDoe);``
``myCompany.Departments.Add(engineeringDept);``


