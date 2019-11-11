using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComparingObjects.Core
{
    public class Engine
    {
        public void Run()
        {
            List<Person> persons = new List<Person>();

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (splitInput.Length == 3)
                {
                    string name = splitInput[0];
                    int age = int.Parse(splitInput[1]);
                    string town = splitInput[2];

                    Person person = new Person(name,age,town);
                    persons.Add(person);
                }
            }

            int targetIndex = int.Parse(Console.ReadLine()) - 1;

            Person targetPerson = persons[targetIndex];

            int totalPersons = persons.Count;
            int equalPersons = 0;
            int nonEqualPersons = totalPersons;

            foreach (var person in persons)
            {
                if (person.CompareTo(targetPerson) == 0)
                {
                    equalPersons++;
                    nonEqualPersons--;
                }
            }

            if (equalPersons > 1)
            {
                Console.WriteLine($"{equalPersons} {nonEqualPersons} {totalPersons}");
            }
            else if (equalPersons == 1)
            {
                Console.WriteLine("No matches");
            }

        }
    }
}
