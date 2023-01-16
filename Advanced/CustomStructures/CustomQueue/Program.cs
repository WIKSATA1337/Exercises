using CustomQueue;

CustomQueue<int> customQueue = new CustomQueue<int>();

customQueue.Enqueue(1);
customQueue.Enqueue(2);
customQueue.Enqueue(3);
customQueue.Enqueue(4);
customQueue.Enqueue(5);
customQueue.Enqueue(6);

Console.WriteLine(customQueue.Dequeue());
Console.WriteLine(customQueue.Dequeue());

Console.WriteLine(customQueue.Peek());

customQueue.Clear();

customQueue.Enqueue(777);

Console.WriteLine(customQueue.Peek());