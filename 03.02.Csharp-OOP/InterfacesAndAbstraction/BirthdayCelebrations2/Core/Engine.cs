using BirthdayCelebrations2.Interfaces;
using BirthdayCelebrations2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations2.Core
{
    public class Engine
    {
        private List<IIdentifiable> citizensRobotsPets;

        public Engine()
        {
            this.citizensRobotsPets = new List<IIdentifiable>();
        }

        public void Run()
        {
            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (splitInput.Length == 5 && splitInput[0] == "Citizen")
                {
                    string name = splitInput[1];
                    int age = int.Parse(splitInput[2]);
                    string id = splitInput[3];
                    string birthday = splitInput[4];

                    IIdentifiable citizen = new Citizen(name, age, id, birthday);
                    citizensRobotsPets.Add(citizen);

                }
                else if (splitInput.Length == 3)
                {
                    if (splitInput[0] == "Pet")
                    {
                        string name = splitInput[1];
                        string birthday = splitInput[2];

                        IIdentifiable pet = new Pet(name, birthday);
                        citizensRobotsPets.Add(pet);
                    }
                    else if (splitInput[0] == "Robot")
                    {
                        string model = splitInput[1];
                        string id = splitInput[2];

                        IIdentifiable robot = new Robot(model, id);
                        citizensRobotsPets.Add(robot);
                    }
                }
            }

            string targetYear = Console.ReadLine();
            Print(targetYear);
        }

        private void Print(string targetYear)
        {
            foreach (var creature in citizensRobotsPets.Where(x => x.Birthdate.EndsWith(targetYear)))
            {
                Console.WriteLine($"{creature.Birthdate}");
            }

            citizensRobotsPets.RemoveAll(x => x.Birthdate.EndsWith(targetYear));
        }
    }
}
