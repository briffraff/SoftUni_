using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumSekundi
{
    class Program
    {
        static void Main(string[] args)
        {

            double sustezatel1 = double.Parse(Console.ReadLine());
            double sustezatel2 = double.Parse(Console.ReadLine());
            double sustezatel3 = double.Parse(Console.ReadLine());

            double sec = (sustezatel1 + sustezatel2 + sustezatel3);

            double minuti = Math.Floor(sec / 60);
            double secs = sec % 60;

            Console.WriteLine($"{minuti:0}:{secs:00}");
        }
    }
}
