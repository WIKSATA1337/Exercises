using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCruncher
{
    class Program
    {
        static void Main()
        {
            // Examples:
            // m, text, me, so, do, m, e, ran
            // somerandomtext

            string[] syllables = Console.ReadLine().Split(", ");
            string targetWord = Console.ReadLine();

            Cruncher cruncher = new Cruncher(syllables, targetWord);

            foreach (var path in cruncher.GetPaths())
            {
                Console.WriteLine(path);
            }
        }
    }

    public class Cruncher
    {
        private class Node
        {
            public string Syllable { get; set; }
            public List<Node> NextSyllables { get; set; }
            public Node(string syllable, List<Node> nextSyllables)
            {
                Syllable = syllable;
                NextSyllables = nextSyllables;
            }
        }

        private List<Node> syllableGroups;
        public Cruncher(string[] syllables, string targetWord)
        {
            syllableGroups = GenerateSyllableGroup(syllables, targetWord);
        }

        private List<Node> GenerateSyllableGroup(string[] syllables, string targetWord)
        {
            if (string.IsNullOrEmpty(targetWord) || syllables.Length == 0)
            {
                return null;
            }

            var resultValues = new List<Node>();

            for (int i = 0; i < syllables.Length; i++)
            {
                var syllable = syllables[i];

                if (targetWord.StartsWith(syllable))
                {
                    var nextSyllables = GenerateSyllableGroup(
                        syllables.Where((_, index) => index != i).ToArray(),
                        targetWord.Substring(syllable.Length)
                        );

                    resultValues.Add(new Node(syllable, nextSyllables));
                }
            }

            return resultValues;
        }

        public IEnumerable<string> GetPaths()
        {
            var allPaths = new List<List<string>>();

            GeneratePaths(syllableGroups, allPaths, new List<string>());

            return new HashSet<string> (allPaths.Select(x => string.Join(" ", x)));
        }

        private void GeneratePaths(List<Node> syllableGroups,
            List<List<string>> allPaths,
            List<string> currentPath)
        {
            if (syllableGroups == null)
            {
                allPaths.Add(new List<string>(currentPath));

                return;
            }

            foreach (var node in syllableGroups)
            {
                currentPath.Add(node.Syllable);

                GeneratePaths(node.NextSyllables, allPaths, currentPath);

                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }
}
