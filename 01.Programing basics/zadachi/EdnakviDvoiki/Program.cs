using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdnakviDvoiki
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var purvaSuma = 0;
            var vtoraSuma = 0;
            var razlika = 0;
            var MaxRazlika = 0;

            // zavurtane na cikul s vuvejdane na 2 chisla ,subiraneto im ,subirane na vtora grupa chisla
            // namirane na razlikata mejdu dvete i zapazvane na tazi razlika ,kato maximalna - ako e nai-golqma;
            for (int i = 0; i < n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                if (i == 0)
                {
                    purvaSuma = num1 + num2;
                }
                else
                {
                    vtoraSuma = num1 + num2;
                    razlika = Math.Abs(vtoraSuma - purvaSuma);
                    if (razlika > MaxRazlika)
                    {
                        MaxRazlika = razlika;
                    }
                    purvaSuma = vtoraSuma;
                }
            }

            //pechatane na rezultat
            if (MaxRazlika == 0)
            {
                Console.WriteLine("Yes, value = {0}", purvaSuma);
            }
            else
            {
                Console.WriteLine("No, maxdiff = {0}", MaxRazlika);
            }
        }
    }
}
