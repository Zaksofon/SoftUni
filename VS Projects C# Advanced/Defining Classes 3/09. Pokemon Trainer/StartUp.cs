using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Tournament")
                {
                    break;
                }

                string[] parts = line
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string trainerName = parts[0];
                string pokemonName = parts[1];
                string pokemonElement = parts[2];
                int pokemonHealth = int.Parse(parts[3]);

                if (trainers.All(n => n.Name != trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                Trainer currentTrainer = trainers.Find(n => n.Name == trainerName);
                currentTrainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Fire" || command == "Water" || command == "Electricity")
                {
                    foreach (var trainer in trainers)
                    {
                        FightPokemons(trainer, command);
                    }
                    continue;
                }

                if (command == "End")
                {
                    trainers = trainers
                        .OrderByDescending(b => b.Badges)
                        .ToList();

                    foreach (var trainer in trainers)
                    {
                        Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
                    }
                    return;
                }
            }
        }

        private static void FightPokemons(Trainer trainer, string command)
        {
            if (trainer.Pokemons.Any(e => e.Element == command))
            {
                trainer.Badges++;
            }
            else
            {
                foreach (var pokemon in trainer.Pokemons)
                {
                    pokemon.Health -= 10;

                    if (trainer.Pokemons.Any(h => h.Health <= 0))
                    {
                        trainer.Pokemons.Remove(trainer.Pokemons.Find(h => h.Health <= 0));
                    }

                    if (trainer.Pokemons.Count == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
