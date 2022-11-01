using CustomList;

CustomList<int> customList = new CustomList<int>();
customList.Add(1);
customList.Add(2);
customList.Add(3);
customList.Add(4);
customList.Add(5);

Console.WriteLine(customList.Contains(4));
Console.WriteLine(customList.Contains(7));

customList.InsertAt(2, 12);

Console.WriteLine();

Console.WriteLine(customList.RemoveAt(4));

customList.Swap(2, 1);

Console.WriteLine();

customList.ForEach(element => Console.WriteLine(element));