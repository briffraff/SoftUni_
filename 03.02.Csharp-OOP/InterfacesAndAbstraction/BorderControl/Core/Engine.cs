using BorderControl.Interfaces;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl.Core
{
    public class Engine
    {
        private List<IIdentifiable> citizensAndRobots;

        public Engine()
        {
            citizensAndRobots = new List<IIdentifiable>();
        }

        public void Run()
        {
            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (splitInput.Length == 3)
                {
                    string name = splitInput[0];
                    int age = int.Parse(splitInput[1]);
                    string id = splitInput[2];

                    IIdentifiable citizen = new Citizen(name, age, id);
                    citizensAndRobots.Add(citizen);
                }
                else if (splitInput.Length == 2)
                {
                    string model = splitInput[0];
                    string id = splitInput[1];

                    IIdentifiable robot = new Robot(model, id);
                    citizensAndRobots.Add(robot);
                }
            }
            string targetId = Console.ReadLine();
            Print(targetId);
            citizensAndRobots.RemoveAll(x => x.Id.EndsWith(targetId));
        }


        public void Print(string targetId)
        {
            foreach (var creature in citizensAndRobots.Where(x => x.Id.EndsWith(targetId)))
            {
                Console.WriteLine($"{creature.Id}");
            }
        }
    }
}
