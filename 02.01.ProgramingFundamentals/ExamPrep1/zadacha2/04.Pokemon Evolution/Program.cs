using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Pokemon_Evolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,List<string>> pokemons = new Dictionary<string, List<string>>();

            string line = "";
            while ((line = Console.ReadLine()) != "wubbalubbadubdub")
            {

                string[] tokens = line.Split(" -> ");
                if (tokens.Length == 3)
                {
                    string pokemonName = tokens[0];
                    string evolutionName = tokens[1];
                    string evolutionIdx = tokens[2];

                    if (pokemons.ContainsKey(pokemonName) == false)
                    {
                        pokemons.Add(pokemonName,new List<string>());
                    }

                    string evolution = evolutionName + " <-> " + evolutionIdx;
                    pokemons[pokemonName].Add(evolution);
                }
                else
                {
                    //print the pokemon if exists
                    string pokemonNametoPrint = tokens[0];

                    if (pokemons.ContainsKey(pokemonNametoPrint))
                    {
                        Console.WriteLine($"# {pokemonNametoPrint}");

                        List<string> evolutions = pokemons[pokemonNametoPrint];
                        foreach (string evolution in evolutions)
                        {
                            Console.WriteLine(evolution);
                        }
                    }
                }
            }

            foreach (var pokemon in pokemons)
            {
                string pokemonName = pokemon.Key;
                Console.WriteLine($"# {pokemonName}");

                List<string> orderedEvolutions = pokemon.Value
                    .OrderByDescending(e =>
                    {
                        int index = int.Parse(e.Split(" <-> ")[1]);
                        return index;
                    })
                    .ToList();

                foreach (string orderedEvolution in orderedEvolutions)
                {
                    Console.WriteLine(orderedEvolution);
                }
            }
        }
    }
}
