namespace TheTankGame.IO
{
    using System;
    using System.Text;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        //fld
        private readonly StringBuilder sb;

        //ctor
        public ConsoleWriter()
        {
            this.sb = new StringBuilder();
        }

        //mthds
        public void WriteLine(string output)
        {
            this.sb.AppendLine(output);
        }

        public void Flush()
        {
            Console.WriteLine(this.sb.ToString().TrimEnd());
        }
    }
}