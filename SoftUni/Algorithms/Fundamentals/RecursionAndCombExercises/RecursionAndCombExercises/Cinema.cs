using System.Text;

namespace RecursionAndCombExercises
{
    public static class Cinema
    {
        private static List<string> movable;
        private static string[] people;
        private static bool[] locked;
        public static void Run()
        {
            movable = Console.ReadLine()
                .Split(", ")
                .ToList();

            people = new string[movable.Count];
            locked = new bool[movable.Count];

            string command;
            while ((command = Console.ReadLine()) != "generate")
            {
                var splittedCommand = command.Split(" - ");
                var name = splittedCommand[0];
                var position = int.Parse(splittedCommand[1]);

                movable.Remove(name);
                locked[position - 1] = true;
                people[position - 1] = name;
            }

            Permute(0);
        }

        private static void Permute(int idx)
        {
            if (idx >= movable.Count)
            {
                PrintPermutation();

                return;
            }

            for (int i = idx + 1; i < movable.Count; i++)
            {
                Swap(idx, i);
                Permute(idx + 1);
                Swap(idx, i);
            }

            Permute(idx + 1);
        }

        private static void PrintPermutation()
        {
            int idx = 0;
            var sb = new StringBuilder();

            for (int i = 0; i < people.Length; i++)
            {
                if (locked[i])
                {
                    sb.Append($"{people[i]} ");
                }
                else
                {
                    sb.Append($"{movable[idx++]} ");
                }
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        private static void Swap(int first, int second)
        {
            (movable[first], movable[second]) = (movable[second], movable[first]);
        }
    }
}
