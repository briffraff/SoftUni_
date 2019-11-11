using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Comparators
{
    public class SortByName : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            int result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

            if (result == 0)
            {
                char firstPersonFirstLetter = Char.ToLower(firstPerson.Name[0]);
                char secondPersonFirstLetter = Char.ToLower(secondPerson.Name[0]);

                result = firstPersonFirstLetter.CompareTo(secondPersonFirstLetter);
            }

            return result;
        }
    }
}
