using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            List<Pokemon> allPokemons = new List<Pokemon>();
            string command;

            while ((command = Console.ReadLine()) != "Tournament")
            {
                var cmdInfo = command.Split(' ');

                var currentPokemon = new Pokemon(cmdInfo[1], cmdInfo[2], int.Parse(cmdInfo[3]));
                allPokemons.Add(currentPokemon);

                if (trainers.Any(t => t.Name == cmdInfo[0]))
                {
                    var foundTrainer = trainers.Where(t => t.Name == cmdInfo[0]).First();
                    foundTrainer.Pokemons.Add(currentPokemon);
                }
                else
                {
                    var currentTrainer = new Trainer(cmdInfo[0]);
                    currentTrainer.Pokemons.Add(currentPokemon);
                    trainers.Add(currentTrainer);
                }
            }

            string untilEnd;

            while ((untilEnd = Console.ReadLine()) != "End")
            {
                TrainerHasPokemonWithElement(trainers, allPokemons, untilEnd);

                CheckForDeadPokemons(trainers, allPokemons);
            }

            trainers = trainers.OrderByDescending(t => t.BadgesCount).ToList();

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }

        private static void CheckForDeadPokemons(List<Trainer> trainers, List<Pokemon> allPokemons)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Health <= 0))
                {
                    var list = trainer.Pokemons.Where(p => p.Health <= 0).ToList();

                    foreach (var poke in list)
                    {
                        trainer.Pokemons.Remove(poke);
                        allPokemons.Remove(poke);
                    }
                }
            }
        }

        private static void TrainerHasPokemonWithElement(List<Trainer> trainers, List<Pokemon> allPokemons, string elementToLookFor)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == elementToLookFor))
                {
                    trainer.BadgesCount++;
                }
                else
                {
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        pokemon.Health -= 10;
                    }
                }
            }
        }
    }
}
