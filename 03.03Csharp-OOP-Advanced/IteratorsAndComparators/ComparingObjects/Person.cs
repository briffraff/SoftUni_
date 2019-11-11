using System;
using System.Collections.Generic;
using System.Text;
using ComparingObjects.Interfaces;

namespace ComparingObjects
{
    public class Person : IPerson , IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name,int age,string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; }
        public int Age { get; }
        public string Town { get; }


        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            if (result == 0)
            {
                result = this.Town.CompareTo(other.Town);
            }

            return result;
        }
    }
}
