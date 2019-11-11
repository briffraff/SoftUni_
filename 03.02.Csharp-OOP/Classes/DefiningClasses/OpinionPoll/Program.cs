using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> list = new List<Person>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] split = Console.ReadLine().Split(" ").ToArray();

                string name = split[0];
                int age = int.Parse(split[1]);

                list.Add(new Person(name, age));
            }

            foreach (var person in list.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
