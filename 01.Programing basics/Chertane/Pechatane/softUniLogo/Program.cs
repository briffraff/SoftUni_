using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softUniLogo
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int visochina = 4 * n - 2;
            int shirina = 12 * n - 5;

            int dots = (shirina - 1) / 2;
            int diez = 1;
            //TOP
            for (int i = 0; i < n * 2; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', dots), new string('#', diez));
                dots -= 3;
                diez += 6;
              
            }

            //MID
            int diezMid = shirina - 6;
            int dotsMidRight = (shirina - diezMid) / 2;
            int dotsMidLeft = ((shirina - diezMid) / 2) - 1;

            for (int i = 0; i < n-2; i++)
            {
                Console.WriteLine("|{0}{1}{2}",new string('.',dotsMidLeft),new string('#',diezMid),new string('.',dotsMidRight));
                dotsMidLeft += 3;
                diezMid -= 6;
                dotsMidRight += 3;
            }

            //BOTT
            //bott cikul 2
            int diezBott = n * 6 + 1;
            int dotsBottLeft = (shirina - diezBott-1) / 2 ;
            int dotsBottRight = (shirina - diezBott)/2;
            
            for (int i = 0; i < n-1 ; i++)
            {
                Console.WriteLine("|{0}{1}{2}",new string('.',dotsBottLeft),new string('#',diezBott),new string('.',dotsBottRight));
            }

            //posleden red
            Console.WriteLine("@{0}{1}{2}", new string('.', dotsBottLeft), new string('#', diezBott), new string('.', dotsBottRight));
        }
    }
}
