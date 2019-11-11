using System;
using System.Collections.Generic;
using System.Linq;
using HAD.Contracts;

namespace HAD.Core
{
    public class Engine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor commandProcessor;

        public Engine(IReader reader, IWriter writer, ICommandProcessor commandProcessor)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandProcessor = commandProcessor;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string inputLine = this.reader.ReadLine();
                IList<string> inputParameters = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string outputResult = this.commandProcessor.Process(inputParameters);

                if (inputLine == "Quit")
                {
                    this.isRunning = false;
                }

                this.writer.WriteLine(outputResult);
            }

            this.writer.Flush();

        }
    }
}