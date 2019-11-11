using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {

            string healthPattern = @"[^0-9+\-\*\/.]";
            string damagePattern = @"([\-\+]?[\d]+[\.]?[\d]+|[\d])";

            //all numbers = baseDamage
            string[] demonsNames = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            double health = 0;
            double damage = 0;

            foreach (var demon in demonsNames.OrderBy(x => x))
            {
                //HEALTH
                MatchCollection healthMatches = Regex.Matches(demon, healthPattern);

                foreach (Match match in healthMatches)
                {
                    foreach (var x in match.ToString())
                    {
                        health += (int)x;
                    }
                }

                // DAMAGE
                MatchCollection damageMatches = Regex.Matches(demon, damagePattern);

                foreach (var currentDamage in damageMatches)
                {
                    damage += double.Parse(currentDamage.ToString());
                }

                foreach (char x in demon.Where(x => x == '*' || x == '/'))
                {
                    if (x == '*')
                    {
                        damage = damage * 2;
                    }

                    if (x == '/')
                    {
                        damage = damage / 2;
                    }
                }

                Console.WriteLine($"{demon} - {health} health, {damage:F2} damage");

                health = 0;
                damage = 0;
            }

        }
    }
}
