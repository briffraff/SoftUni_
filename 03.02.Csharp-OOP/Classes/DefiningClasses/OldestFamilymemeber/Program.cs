using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DefiningClasses
{
    public class StartUp

    {
        public static void Main(string[] args)
        {
            Family list = new Family();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ").ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);

                list.AddMember(new Person(name, age));
            }

            Person oldestMember = list.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");

        }

    }
}
