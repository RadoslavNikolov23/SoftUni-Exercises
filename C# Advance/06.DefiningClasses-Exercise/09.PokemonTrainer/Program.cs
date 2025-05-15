using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommands = Console.ReadLine();
            Dictionary<string, Trainer> pokemonTrainersDT = new Dictionary<string, Trainer>();

            while (inputCommands != "Tournament")
            {
                string[] data = inputCommands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = data[0], pokemonName = data[1], pokemontElement = data[2];
                int pokemonHealth = int.Parse(data[3]);

                if (!pokemonTrainersDT.ContainsKey(trainerName))
                {
                    pokemonTrainersDT[trainerName] = new Trainer(trainerName, 0,
                        new List<Pokemon>() { new Pokemon(pokemonName, pokemontElement, pokemonHealth) });
                }
                else
                {
                    pokemonTrainersDT[trainerName].Pokemon.Add(new Pokemon(pokemonName, pokemontElement, pokemonHealth));
                }

                inputCommands = Console.ReadLine();
            }

            inputCommands = Console.ReadLine();

            while (inputCommands != "End")
            {
                string element = inputCommands;

                foreach (var pokemon in pokemonTrainersDT.Values)
                {
                    if (pokemon.Pokemon.Any(x => x.Element == element))
                    {
                        pokemon.Badges++;
                    }
                    else
                    {
                        Stack<Pokemon> stackForRemovel = new Stack<Pokemon>();
                        foreach (var pokemons in pokemon.Pokemon)
                        {
                            pokemons.Health -= 10;
                            if (pokemons.Health <= 0)
                                stackForRemovel.Push(pokemons);
                        }

                        while(stackForRemovel.Count>0)
                        {
                            pokemon.Pokemon.Remove(stackForRemovel.Pop());
                        }
                    }
                }
                inputCommands = Console.ReadLine();
            }

            foreach (var (trainer, pokemons) in pokemonTrainersDT.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine($"{trainer} {pokemons.Badges} {pokemons.Pokemon.Count}");
            }
        }
    }
}
