using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            var result = RemoveTown(context);

            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesResult = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName} {e.MiddleName}",
                    e.JobTitle,
                    e.Salary
                });

            foreach (var employee in employeesResult)
            {
                sb.AppendLine($"{employee.Name} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var results = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName);

            foreach (var emp in results)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var results = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            foreach (var emp in results)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from Research and Development - ${emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var emp = context.Employees
                .First(e => e.LastName == "Nakov");

            emp.Address = newAddress;

            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine(a);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Include(x => x.Manager)
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(e => e.EmployeesProjects
                    .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Take(10);

            foreach (var emp in employees)
            {
                var empName = emp.FirstName + " " + emp.LastName;
                string managerName = "";

                if (emp.Manager is null)
                {
                    managerName = null;
                }
                else
                {
                    managerName = emp.Manager.FirstName + " " + emp.Manager.LastName;
                }

                sb.AppendLine($"{empName} - Manager: {managerName}");

                var projects = emp.EmployeesProjects
                    .Select(ep => new
                    {
                        ep.Project.Name,
                        ep.Project.StartDate,
                        ep.Project.EndDate
                    })
                    .ToList();

                foreach (var project in projects)
                {
                    string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                    string endDate = "not finished";

                    if (project.EndDate != null)
                    {
                        endDate = project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt");
                    }

                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .Select(x => new
                {
                    x.AddressText,
                    EmployeesCount = x.Employees.Count,
                    TownName = x.Town.Name
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10);

            foreach (var adr in addresses)
            {
                sb.AppendLine($"{adr.AddressText}, {adr.TownName} - {adr.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            
            var employee = context.Employees
                .First(e => e.EmployeeId == 147);

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            var projects = context.EmployeesProjects
                .Where(ep => ep.EmployeeId == employee.EmployeeId)
                .Select(ep => ep.Project)
                .OrderBy(p => p.Name);

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    d.Name,
                    d.Manager,
                    d.Employees
                })
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name);

            foreach (var dep in departments)
            {
                var managerName = $"{dep.Manager.FirstName} {dep.Manager.LastName}";
                sb.AppendLine($"{dep.Name} - {managerName}");

                foreach (var employee in dep.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                {
                    var employeeName = $"{employee.FirstName} {employee.LastName}";
                    sb.AppendLine($"{employeeName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(p => p.Name);

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                    e.Department.Name == "Tool Design" ||
                    e.Department.Name == "Marketing" ||
                    e.Department.Name == "Information Services");

            foreach (var e in employees)
            {
                e.Salary += e.Salary * 0.12m;
            }

            context.SaveChanges();

            var emp = employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            foreach (var e in emp)
            {
                var fullName = $"{e.FirstName} {e.LastName}";

                sb.AppendLine($"{fullName} (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.FirstName);

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToDelete = context.Projects
                .First(p => p.ProjectId == 2);

            var ep = context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList();

            context.EmployeesProjects.RemoveRange(ep);

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context.Projects
                .Select(x => x.Name)
                .Take(10);

            return string.Join(Environment.NewLine, projects);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var employeesToDelete = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle");

            foreach (var employee in employeesToDelete)
            {
                employee.Address = null;
                employee.AddressId = null;
            }

            context.SaveChanges();

            var addressesToDelete = context.Addresses
                .Where(a => a.Town.Name == "Seattle");

            int count = addressesToDelete.Count();

            context.Addresses.RemoveRange(addressesToDelete);

            context.SaveChanges();

            var townToDelete = context.Towns
                .First(t => t.Name == "Seattle");

            context.Towns.Remove(townToDelete);

            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }
    }
}