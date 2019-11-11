namespace SoftUni
{
    using System.Globalization;
    using Models;
    using System;
    using System.Linq;
    using System.Text;
    using Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var result = RemoveTown(context);
                //var result = DeleteProjectById(context);
                //var result = GetEmployeesByFirstNameStartingWithSa(context);
                //var result = IncreaseSalaries(context);
                //var result = GetLatestProjects(context);
                //var result = GetDepartmentsWithMoreThan5Employees(context);
                //var result = GetAddressesByTown(context);
                //var result = GetEmployee147(context);
                //var result = GetEmployeesInPeriod(context);
                //var result = AddNewAddressToEmployee(context);
                //var result = GetEmployeesFromResearchAndDevelopment(context);
                //var result = GetEmployeesWithSalaryOver50000(context);
                //var result = GetEmployeesFullInformation(context);

                Console.WriteLine(result);
            }
        }

        //MTHDS

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns.Where(t => t.Name == "Seattle").ToList();

            var townId = context.Towns
                .Where(t => t.Name == "Seattle")
                .Select(t => t.TownId)
                .FirstOrDefault();

            var addressId = context.Addresses
                .Where(a => a.TownId == townId)
                .Select(x => new
                {
                    x.AddressId,
                    EmployeesList = x.Employees
                           .Select(e => e.AddressId)
                           .ToList()
                })
                .ToList();

            var addresses = context.Addresses
                .Where(a => a.AddressId == townId)
                .ToList();

            //var employees = context.Employees
            //    .Where(e => e.AddressId == addressId)
            //    .ToList();

            
            //employees.ForEach(e => e.AddressId = null);

            context.Addresses.RemoveRange(addresses);
            context.Towns.RemoveRange(town);

            context.SaveChanges();

            return $"{addresses.Count} addresses in Seattle were deleted";
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.Where(p => p.ProjectId == 2).ToList();
            context.Projects.RemoveRange(project);

            var projectEmployees = context.EmployeesProjects.Where(p => p.ProjectId == 2).ToList();
            context.EmployeesProjects.RemoveRange(projectEmployees);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var proj in projects)
            {
                sb.AppendLine(proj);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }
            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                            || e.Department.Name == "Tool Design"
                            || e.Department.Name == "Marketing"
                            || e.Department.Name == "Information Services")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    NewSalary = ((double)e.Salary * 1.12),
                    empFullName = e.FirstName + " " + e.LastName
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.empFullName} (${employee.NewSalary:F2})");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            //Write a program that return information about the last 10 started projects. 
            //Sort them by name lexicographically and return their name, description and start date, each on a new row.
            //    Format of the output
            //Constraints
            //Use date format: "M/d/yyyy h:mm:ss tt".

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    ProjectName = p.Name,
                    p.Description,
                    p.StartDate
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.ProjectName);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(a => a.Employees.Count > 5)
                .OrderBy(e => e.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFullName = x.Manager.FirstName + " " + x.Manager.LastName,

                    EmployeesList = x.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle,
                        EmployeeFullName = e.FirstName + " " + e.LastName,
                    })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .ToList()
                })
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {

                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFullName}");
                foreach (var employee in department.EmployeesList)
                {
                    sb.AppendLine($"{employee.EmployeeFullName} - {employee.JobTitle}");
                }

            }
            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                           .Select(a => new
                           {
                               empCount = a.Employees.Count,
                               townName = a.Town.Name,
                               a.AddressText
                           })
                           .OrderByDescending(a => a.empCount)
                           .ThenBy(a => a.townName)
                           .ThenBy(a => a.AddressText)
                           .Take(10)
                           .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.townName} - {address.empCount} employees");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {

            var emplooyee147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    employerFullName = e.FirstName + " " + e.LastName,
                    jobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(p => new
                        {
                            projectName = p.Project.Name,
                        })
                        .OrderBy(p => p.projectName)
                        .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in emplooyee147)
            {
                sb.AppendLine($"{emp.employerFullName} - {emp.jobTitle}");

                foreach (var proj in emp.Projects)
                {
                    sb.AppendLine($"{proj.projectName}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            var employees = context.Employees
                .Where(p => p.EmployeesProjects.Any(d => d.Project.StartDate.Year >= 2001 && d.Project.StartDate.Year <= 2003))
                .Select(a => new
                {
                    EmployeeFullname = a.FirstName + " " + a.LastName,
                    ManagerFullName = a.Manager.FirstName + " " + a.Manager.LastName,
                    Projects = a.EmployeesProjects
                        .Select(p => new
                        {
                            ProjectName = p.Project.Name,
                            p.Project.StartDate,
                            p.Project.EndDate
                        })
                        .ToList()
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFullname} - Manager: {employee.ManagerFullName}");

                foreach (var project in employee.Projects)
                {
                    var projectName = project.ProjectName;
                    var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var endDate = project.EndDate.HasValue ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";

                    sb.AppendLine($"--{projectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {

            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            var nakov = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            nakov.Address = newAddress;

            context.SaveChanges();

            var employeeAddresses = context.Employees
                .OrderByDescending(x => x.Address)
                .Select(a => new
                {
                    address = a.Address.AddressText
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employeeAddresses)
            {
                sb.AppendLine($"{emp.address}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary,
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var emp in employees)
            {

                sb.AppendLine($"{emp.FirstName} {emp.LastName} from Research and Development - {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeId
                })
                .OrderBy(e => e.EmployeeId);

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}
