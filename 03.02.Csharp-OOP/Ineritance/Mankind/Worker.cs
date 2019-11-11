using System;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        //fields
        private decimal salary;
        private int workingHours;

        //ctor
        public Worker(string firstName, string secondName, decimal salary, int workingHours) : base(firstName, secondName)
        {
            this.Salary = salary;
            this.WorkingHours = workingHours;
        }

        //prop
        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                salary = value;
            }
        }

        public int WorkingHours
        {
            get { return workingHours; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                workingHours = value;
            }
        }


        public override string ToString()
        {
            var resultBuilder = new StringBuilder();

            resultBuilder.AppendLine($"First Name: {this.FirstName}")
                .AppendLine($"Last Name: {this.SecondName}")
                .AppendLine($"Week Salary: {this.Salary:f2}")
                .AppendLine($"Hours per day: {this.WorkingHours:f2}")
                .AppendLine($"Salary per hour: {(this.Salary / (this.WorkingHours * 5)):f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }

    }
}
