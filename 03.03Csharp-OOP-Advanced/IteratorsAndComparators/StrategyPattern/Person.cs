using StrategyPattern.Interfaces;
using System;

namespace StrategyPattern
{
    public class Person : IPerson , IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }
        public int Age { get; }


        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }

        public override bool Equals(object objPerson)
        {
            if (objPerson is Person otherPerson)
            {
                return this.Name == otherPerson.Name && this.Age == otherPerson.Age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }



    }
}
