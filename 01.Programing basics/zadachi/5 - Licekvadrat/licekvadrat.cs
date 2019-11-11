using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Licekvadrat

{
class Licekvadrat_BB
{
static void Main(string[] args)
{
        Console.WriteLine("Vuvedete strana a: ");
        var a = double.Parse(Console.ReadLine());
        Console.WriteLine("Vuvedete strana b: ");
        var b = double.Parse(Console.ReadLine());
        var sum = (a*b);
        Console.WriteLine("Liceto na pravougulnika e: ");
        Console.WriteLine(sum + " cm2");
}
}
}
