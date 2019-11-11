using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Core
{
    public class EngineEqualityLogic
    {
        public void Run()
        {
            SortedSet<Person> personsSorted = new SortedSet<Person>();
            HashSet<Person> personsByHash = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] splitInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (splitInput.Length == 2)
                {
                    string name = splitInput[0];
                    int age = int.Parse(splitInput[1]);

                    Person person = new Person(name, age);
                    personsSorted.Add(person);
                    personsByHash.Add(person);
                }
            }

            Console.WriteLine(personsSorted.Count);
            Console.WriteLine(personsByHash.Count);
        }
    }
}
