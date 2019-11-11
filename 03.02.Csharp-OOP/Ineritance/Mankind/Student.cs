using System;
using System.Text;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string secondName,string facultyNumber) : base(firstName, secondName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public virtual string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();

            resultBuilder.AppendLine($"First Name: {this.FirstName}")
                .AppendLine($"Last Name: {this.SecondName}")
                .AppendLine($"Faculty number: {this.FacultyNumber}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }
    }
}
