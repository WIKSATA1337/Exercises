using CustomStack;

CustomStack<int> stack = new CustomStack<int>();

stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Push(4);
stack.Push(5);
stack.Push(6);

stack.PrintStack();

// Console.WriteLine();
//stack.ForEach(element => Console.WriteLine(element));

Console.WriteLine();

Console.WriteLine(stack.Pop());

Console.WriteLine();

Console.WriteLine(stack.Peek());