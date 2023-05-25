namespace RecursionAndCombExercises
{
    public static class WordCruncher
    {
        private static Dictionary<int, List<string>> wordsByIdx;
        private static Dictionary<string, int> wordsCount;
        private static LinkedList<string> usedWords;
        private static string targetWord;

        public static void Run()
        {
            wordsByIdx = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            usedWords = new LinkedList<string>();

            var words = Console.ReadLine().Split(", ");
            targetWord = Console.ReadLine();

            foreach (var word in words)
            {
                var idx = targetWord.IndexOf(word);

                if (idx < 0)
                {
                    continue;
                }

                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                    continue;
                }

                wordsCount[word] = 1;

                while (idx != -1)
                {
                    if (!wordsByIdx.ContainsKey(idx))
                    {
                        wordsByIdx[idx] = new List<string>();
                    }

                    wordsByIdx[idx].Add(word);

                    idx = targetWord.IndexOf(word, idx + 1);
                }
            }

            GenerateResults(0);
        }

        private static void GenerateResults(int idx)
        {
            if (idx == targetWord.Length)
            {
                Console.WriteLine(string.Join(" ", usedWords));
                return;
            }

            if (!wordsByIdx.ContainsKey(idx))
            {
                return;
            }

            foreach (var word in wordsByIdx[idx])
            {
                if (wordsCount[word] is 0)
                {
                    continue;
                }

                wordsCount[word]--;
                usedWords.AddLast(word);

                GenerateResults(idx + word.Length);

                usedWords.RemoveLast();
                wordsCount[word]++;
            }
        }
    }
}