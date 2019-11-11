using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator.Core
{
    public class Engine
    {
        private ListyIterator<string> listyIterator;
        private string[] data;
        private string createCommand;

        public Engine()
        {
            data = inputSplit.Skip(1).ToArray();
            createCommand = inputSplit[0];

            if (createCommand == "Create")
            {
                listyIterator = new ListyIterator<string>(data);
            }
        }

        string[] inputSplit = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        public void Run()
        {
            string nextCommand = "";

            while ((nextCommand = Console.ReadLine()) != "END")
            {
                switch (nextCommand)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "PrintAll":
                        listyIterator.PrintAll();
                        break;
                }
            }

        }
    }
}
