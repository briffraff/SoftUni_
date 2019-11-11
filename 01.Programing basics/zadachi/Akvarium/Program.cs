using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akvarium
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vuvejdane na duljina;
            Console.Write("Vuvedete duljina: ");
            var duljina = int.Parse(Console.ReadLine());

            //Vuvejdane na shirochina
            Console.Write("Vuvedete shirochina: ");
            var shirochina = int.Parse(Console.ReadLine());

            //Vuvejdane na visochina
            Console.Write("Vuvedete visochina: ");
            var visochina = int.Parse(Console.ReadLine());

            //Vuvejdane na procent aksesoari
            Console.Write("Vuvedete procent zaet ot aksesoarite v akvariuma: ");
            double procent = double.Parse(Console.ReadLine());

            //prisvoqvane na promenlivi
            var d = duljina;
            var s = shirochina;
            var v = visochina;
            double p = procent;

            //subirane na prednite v edna obshta
            var i = d + s + v;

            //proverka na zadadenite predvaritelno usloviq 
            //Tui kato duljinata , visochinata i shirinata trqbva da zapochvat ot 10 
            //proverkata na vutreshniq "if" shte se osushtestvi ako sbora ot trite "i" e 30 ili nad 30
            //Osushtestvi li se - Proverkata pechati vseki ot parametrite ako e pod 10
            if (i >= 30)
            {
               
                if (d >= 10 && d <= 500)
                {

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("!- Chisloto {0} ne e v diapazona -!", duljina);
                }

                if (s >= 10 && s <= 300)
                {

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("!- Chisloto {0} ne e v diapazona -!", shirochina);
                }

                if (v >= 10 && v <= 200)
                {

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("!- Chisloto {0} ne e v diapazona -!", visochina);
                }

                if (p >= 0.000 && p <= 100.000)
                {

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("!- Chisloto {0} ne e v diapazona -!", procent);
                    

                }
                Console.WriteLine();
                
            }

            //Ako nito edno ot chislata ne otgovarq na prednata proverka
            else
            {
                Console.WriteLine();
                Console.WriteLine("!- Ne ste v diapazona s razmeri -!");
                Console.WriteLine();
            }
            

            if (d >= 10 && s>=10 && v>=10 && p<=100 | d <= 500 && s <= 300 && v <= 200 && p >= 0) 
            {
                //izchislqvane na vodata
                var obem = (d * s * v) * 0.001;
                var proc = procent / 100;
                var chistoLitri = (obem - (obem * proc));

                //izchislqvane na kolichestvoto na aksesoarite
                //var aksesoari = (Math.Round((obem * proc), 3));

                //Pechatane na rezultata
                Console.WriteLine("Akvariumut shte pobere : {0:f3} litra voda" ,chistoLitri);
                Console.WriteLine();
                Console.WriteLine("Kolichestvoto na aksesoarite e {0} % ot obshtiq obem na akvariuma !", procent);
                Console.WriteLine();
            }
          
        }
        
    }
}
