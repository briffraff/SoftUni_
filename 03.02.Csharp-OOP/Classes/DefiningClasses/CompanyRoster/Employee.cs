using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyRoster
{
    public class Employee
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
}
