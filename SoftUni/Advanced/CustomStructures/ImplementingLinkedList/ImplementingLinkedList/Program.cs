using System;
using System.Threading;

namespace ImplementingLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedListInt();

            Console.WriteLine();
            Thread.Sleep(2000);

            LinkedListString();
        }

        public static void LinkedListInt()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.AddFirst(1);
            linkedList.AddLast(2);
            linkedList.AddFirst(3);
            linkedList.AddLast(4);
            linkedList.AddFirst(5);
            linkedList.AddLast(6);
            linkedList.AddFirst(7);
            linkedList.AddLast(8);

            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            int firstValue = linkedList.RemoveFirst();
            int lastValue = linkedList.RemoveLast();

            linkedList.ForEach(number =>
            {
                Console.WriteLine(number);
            });

            Console.WriteLine(string.Join(" => ", linkedList.ToArray()));
        }

        public static void LinkedListString()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            linkedList.AddFirst("One");
            linkedList.AddLast("Two");
            linkedList.AddFirst("Three");
            linkedList.AddLast("Four");
            linkedList.AddFirst("Five");
            linkedList.AddLast("Six");
            linkedList.AddFirst("Seven");
            linkedList.AddLast("Eight");

            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            string firstValue = linkedList.RemoveFirst();
            string lastValue = linkedList.RemoveLast();

            linkedList.ForEach(number =>
            {
                Console.WriteLine(number);
            });

            Console.WriteLine(string.Join(" => ", linkedList.ToArray()));
        }
    }
}
