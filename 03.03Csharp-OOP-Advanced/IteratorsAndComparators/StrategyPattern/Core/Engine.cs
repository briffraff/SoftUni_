using System;
using System.Collections.Generic;
using System.Text;
using StrategyPattern.Comparators;

namespace StrategyPattern.Core
{
    public class Engine
    {
        public void Run()
        {
            SortedSet<Person> personsByName = new SortedSet<Person>(new SortByName());
            SortedSet<Person> personsByAge = new SortedSet<Person>(new SortByAge());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] splitInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (splitInput.Length == 2)
                {
                    string name = splitInput[0];
                    int age = int.Parse(splitInput[1]);

                    Person person = new Person(name, age);
                    personsByName.Add(person);
                    personsByAge.Add(person);
                }

            }

            Console.WriteLine(string.Join("\n", personsByName));
            Console.WriteLine(string.Join("\n", personsByAge));

        }
    }
}
