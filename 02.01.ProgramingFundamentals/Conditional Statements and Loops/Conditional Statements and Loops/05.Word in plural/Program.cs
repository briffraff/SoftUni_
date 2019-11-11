using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Word_in_plural
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int lastIndex = word.Length-1;
            char lastSymbol = word[lastIndex];

            //Console.WriteLine(word.Length);
            //Console.WriteLine(lastIndex);
            //Console.WriteLine(word[lastIndex]);

            if (lastSymbol == 'y')
            {
                word = word.Replace("y", "ies");
            }
            else if(word.EndsWith("o") || word.EndsWith("ch") || word.EndsWith("s") || word.EndsWith("sh") || word.EndsWith("x") || word.EndsWith("z"))
            {
                word = word + "es";
            }
            else
            {
                word = word + "s";
            }

            Console.WriteLine(word);
        }
    }
}
