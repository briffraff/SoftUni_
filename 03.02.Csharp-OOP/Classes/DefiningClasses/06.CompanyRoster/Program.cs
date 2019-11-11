using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private string department;
        public string email;
        public int age;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = "n/a";
            this.age = -1;
        }

        public string Name => this.name;
        public decimal Salary => this.salary;
        public string Position => this.position;
        public string Department => this.department;
        //public string Email => this.email;
        //public int Age => this.age;
    }
    static void Main(string[] args)
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
            .GroupBy(e => e.Department)
            .Select(e => new
            {
                Department = e.Key,
                AverageSalary = e.Average(emp => emp.Salary),
                Employees = e.OrderByDescending(emp => emp.Salary)

            })
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {result.Department}");

        foreach (var em in result.Employees)
        {
            Console.WriteLine($"{em.Name} {em.Salary:F2} {em.email} {em.age}");
        }
    }
}

