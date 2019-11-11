using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CustomList.Core
{
    public class Engine
    {
        private List<string> list;

        public Engine()
        {
            list = new List<string>();
        }

        public void Run()
        {

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                var splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var command = splitInput[0];

                if (command == "Print")
                {
                    break;
                }

                Box<string> box = new Box<string>(list);

                switch (command)
                {
                    case "Add":
                        var element = splitInput[1];
                        list.Add(element);
                        break;

                    case "Remove":
                        var targetIndex = int.Parse(splitInput[1]);
                        box.Remove(targetIndex);
                        break;

                    case "Contains":
                        var elementToCheck = splitInput[1];
                        box.Contains(elementToCheck);
                        break;

                    case "Swap":
                        string[] indexes = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        int index1 = int.Parse(indexes[1]);
                        int index2 = int.Parse(indexes[2]);
                        box.Swap(index1, index2);
                        break;

                    case "Greater":
                        string GreaterElement = splitInput[1];
                        var result = box.GetGreaterThan(GreaterElement);
                        Console.WriteLine(result);
                        break;

                    case "Max":
                        box.MaxValue();
                        break;

                    case "Min":
                        box.MinValue();
                        break;
                    case "Sort":
                        list = new List<string>(list.OrderBy(x => x));
                        break;

                }

            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
