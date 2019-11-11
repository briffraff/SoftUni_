using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int employeeNumber = int.Parse(Console.ReadLine());

            var employeesList = new List<Employee>();

            for (int i = 0; i < employeeNumber; i++)
            {
                string[] employeeInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string Xname = employeeInfo[0];
                decimal Xsalary = decimal.Parse(employeeInfo[1]);
                string Xposition = employeeInfo[2];
                string Xdepartment = employeeInfo[3];

                var employee = new Employee(Xname, Xsalary, Xposition, Xdepartment);

                if (employeeInfo.Length > 5)
                {
                    employee.age = int.Parse(employeeInfo[5]);
                }

                if (employeeInfo.Length > 4)
                {
                    var ageOrEmail = employeeInfo[4];
                    if (ageOrEmail.Contains("@"))
                    {
                        employee.email = ageOrEmail;
                    }
                    else
                    {
                        //.Age - it is read only 
                        employee.age = int.Parse(ageOrEmail);
                    }
                }

                employeesList.Add(employee);
            }

            var result = employeesList
                .GroupBy(x => x.Department)
                .ToDictionary(x => x.Key, y => y.Select(s => s))
                .OrderByDescending(x=>x.Value.Average(s=>s.Salary))
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Key}");

            foreach (var employee in result.Value.OrderByDescending(x=>x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.email} {employee.age}");
            }
        }
    }
}
