using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Comparators
{
    public class SortByAge : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            int result = firstPerson.Age.CompareTo(secondPerson.Age);

            return result;
        }
    }
}
