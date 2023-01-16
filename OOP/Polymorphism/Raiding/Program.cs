using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        static void Main()
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int heroesCount = int.Parse(Console.ReadLine());

            while (heroes.Count < heroesCount)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine().ToLower();

                if (heroType == "druid")
                {
                    heroes.Add(new Druid(heroName, 80));
                }
                else if (heroType == "paladin")
                {
                    heroes.Add(new Paladin(heroName, 100));
                }
                else if (heroType == "rogue")
                {
                    heroes.Add(new Rogue(heroName, 80));
                }
                else if (heroType == "warrior")
                {
                    heroes.Add(new Warrior(heroName, 100));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalPower = 0;
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                totalPower += hero.Power;
            }

            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
