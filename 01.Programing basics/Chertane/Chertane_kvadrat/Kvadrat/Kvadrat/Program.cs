using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chertane_kvadrat
{
    class Kvadrat
    {
        static void Main(string[] args)
        {

            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            for (int row = 0; row < rows; row++)
            {
                Console.Write("*");

                for (int col = 0; col < cols - 1; col++)
                {
                    Console.Write(" *");

                }
                Console.WriteLine();
            }
        }
    }
}
