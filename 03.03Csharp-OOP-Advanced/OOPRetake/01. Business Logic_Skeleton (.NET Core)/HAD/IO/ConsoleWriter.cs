
namespace HAD.IO
{

    using Contracts;
    using System;
    using System.Text;


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
            sb.AppendLine(output);
        }

        public void Flush()
        {
            Console.WriteLine(this.sb.ToString().TrimEnd());
        }
    }
}