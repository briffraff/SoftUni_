using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Character_Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine(); //name

            int currHealth = int.Parse(Console.ReadLine()); //current health
            int maxHealth = int.Parse(Console.ReadLine()); //max health
            int currEnergy = int.Parse(Console.ReadLine()); //current energy
            int maxEnergy = int.Parse(Console.ReadLine()); //max energy

            Console.WriteLine("Name: {0}",name);
            Console.WriteLine("Health: |{0}{1}|",new string('|', currHealth), new string('.',maxHealth - currHealth));
            Console.WriteLine("Energy: |{0}{1}|", new string('|', currEnergy), new string('.', maxEnergy - currEnergy));
        }
    }
}
