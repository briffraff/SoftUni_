using FoodShortage.Interfaces;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage.Core
{
    public class Engine
    {
        private List<Citizen> citizens;
        private List<Rebel> rebels;
        int points = 0;

        public Engine()
        {
            this.citizens = new List<Citizen>();
            this.rebels = new List<Rebel>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] splitInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (splitInput.Length == 4)
                {
                    string name = splitInput[0];
                    int age = int.Parse(splitInput[1]);
                    string id = splitInput[2];
                    string birthday = splitInput[3];

                    Citizen citizen = new Citizen(name, age, id, birthday);
                    citizens.Add(citizen);
                }

                if (splitInput.Length == 3)
                {
                    string name = splitInput[0];
                    int age = int.Parse(splitInput[1]);
                    string group = splitInput[2];

                    Rebel rebel = new Rebel(name, age, group);
                    rebels.Add(rebel);
                }
            }

            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string name = input;

                foreach (var citizen in citizens)
                {
                    if (citizen.Name == name)
                    {
                        citizen.BuyFood();
                        points += citizen.Food;
                    }
                }

                foreach (var rebel in rebels)
                {
                    if (rebel.Name == name)
                    {
                        rebel.BuyFood();
                        points += rebel.Food;
                    }
                }
            }

            Print();
        }

        private void Print()
        {
            Console.WriteLine(points);
        }
    }
}
