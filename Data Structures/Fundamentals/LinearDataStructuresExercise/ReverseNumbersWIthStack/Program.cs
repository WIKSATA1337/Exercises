int[] inputNumbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

Stack<int> reversed = new Stack<int>();

// Automatic way
// Stack<int> reversed = new Stack<int>(inputNumbers);

for (int i = 0; i < inputNumbers.Length; i++)
{
    reversed.Push(inputNumbers[i]);
}

Console.WriteLine(string.Join(" ", reversed));