using System;
using System.Collections.Generic;
using System.Text;

namespace Village.Controllers
{
    public class Controller
    {
        List<Village> villages = new List<Village>();
        List<Rebel> rebels = new List<Rebel>();
        private int attacksCount = 0;

        public string ProcessVillageCommand(List<string> args)
        {
            Village village = new Village(args[0], args[1]);
            villages.Add(village);

            return $"Created Village {args[0]}!";
        }

        public string ProcessSettleCommand(List<string> args)
        {
            Peasant peasant = new Peasant(args[0], int.Parse(args[1]), int.Parse(args[2]));
            var foundVillage = villages.Find(village => village.Name == args[3]);
            foundVillage.AddPeasant(peasant);

            return $"Settled Peasant {peasant.Name} in Village {foundVillage.Name}!";
        }

        public string ProcessRebelCommand(List<string> args)
        {
            Rebel rebel = new Rebel(args[0], int.Parse(args[1]), int.Parse(args[2]));
            rebels.Add(rebel);

            return $"Rebel {rebel.Name} joined the gang!";
        }

        public string ProcessDayCommand(List<string> args)
        {
            var foundVillage = villages.Find(village => village.Name == args[0]);
            int result = foundVillage.PassDay();

            return $"Village {foundVillage.Name} resource increased with {result}!";
        }

        public string ProcessAttackCommand(List<string> args)
        {
            int attackersCount = int.Parse(args[0]);
            string villageToAttack = args[1];

            string result = "";

            if (rebels.Count == 0)
            {
                result = "No rebels to perform raid...";
            }
            else
            {
                attacksCount++;
                int harm = 0;

                for (int i = 0; i < attackersCount; i++)
                {
                    harm += rebels[i].Harm;
                }

                var foundVillage = villages.Find(village => village.Name == villageToAttack);
                foundVillage.Resource -= harm;

                if (attackersCount > 1)
                {
                    var killed = foundVillage.KillPeasants(attackersCount / 2);
                    result = $"Village {foundVillage.Name} lost {harm} resources and {killed.Count} peasants!";
                }
                else
                {
                    result = $"Village {foundVillage.Name} lost {harm} resources and 0 peasants!";
                }
            }

            return result;
        }
        public string ProcessInfoCommand(List<string> args)
        {
            if (args[0] == "Rebel")
            {
                if (rebels.Count == 0)
                {
                    return "No Rebels";
                }

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Rebels:");
                foreach (var rebel in rebels)
                {
                    sb.AppendLine(rebel.ToString());
                }

                return sb.ToString();
            }
            else
            {
                if (villages.Count == 0)
                {
                    return "No Villages";
                }

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Villages:");
                foreach (var village in villages)
                {
                    List<Peasant> currentVillagePeasants = village.GetPeasants();

                    sb.AppendLine(village.ToString());
                    sb.AppendLine();
                }

                return sb.ToString();
            }
        }

        public string ProcessEndCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Villages: {villages.Count}");
            sb.AppendLine($"Rebels: {rebels.Count}");
            sb.AppendLine($"Attacks on Villages: {attacksCount}");

            return sb.ToString();
        }
    }
}
