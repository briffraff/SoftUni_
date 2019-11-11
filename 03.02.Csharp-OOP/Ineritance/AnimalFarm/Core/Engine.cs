using AnimalFarm.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AnimalFarm.Core
{

    public class Engine
    {
        Dictionary<string, List<Animal>> animals = new Dictionary<string, List<Animal>>();

        public void Run()
        {
            string input = "";
            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string animalType = input;
                    string[] animalProps = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (animalProps.Length != 3)
                    {
                        throw new InvalidInputException();
                    }

                    string animalName = animalProps[0];
                    int animalAge = int.Parse(animalProps[1]);
                    string animalGender = animalProps[2];

                    Animal animal = new Animal(animalName, animalAge, animalGender);


                    if (animals.ContainsKey(animalType) == false)
                    {
                        animals.Add(animalType, new List<Animal>());
                    }

                    if (animals[animalType].Contains(animal) == false)
                    {
                        animals[animalType].Add(animal);
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);

                }

            }
        }

        public void Print()
        {
            string sound = "";
            string animType = "";

            foreach (var animal in animals)
            {
                animType = animal.Key;
                Console.WriteLine(animal.Key);

                foreach (var anim in animal.Value)
                {
                    sound = anim.ProduceSound(animType);
                    Console.WriteLine($"{anim.Name} {anim.Age} {anim.Gender}");
                }

                Console.WriteLine(sound);
            }
        }
    }
}
