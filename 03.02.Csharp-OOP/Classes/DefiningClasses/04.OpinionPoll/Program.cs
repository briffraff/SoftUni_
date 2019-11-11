using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {

        int participantsCount = int.Parse(Console.ReadLine());

        var list = new List<Person>();

        for (int i = 0; i < participantsCount; i++)
        {
            string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);

            list.Add(new Person(name, age));
        }

        foreach (var person in list.Where(p => p.Age > 30).OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }

    }
}

