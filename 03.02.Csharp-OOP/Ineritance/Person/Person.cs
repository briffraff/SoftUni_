using System;
using System.Text;

namespace Person
{
    public class Person
    {
        //fields
        private string name;
        private int age;

        //ctor
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        //properties
        public virtual string Name
        {
            get { return name; }
            set
            {
                if (value.Length >= 3)
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }
            }
        }

        public virtual int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }

                if (value > 0)
                {
                    age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {this.Name}, Age: {this.Age}");

            return sb.ToString();
        }

    }
}
