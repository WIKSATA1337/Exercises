using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();
            CustomTuple<string, string> tupleOne = new CustomTuple<string, string>(input[0] + " " + input[1], input[2]);


            string[] inputTwo = Console.ReadLine()
                .Split();
            CustomTuple<string, int> tupleTwo = new CustomTuple<string, int>(inputTwo[0], int.Parse(inputTwo[1]));


            string[] inputThree = Console.ReadLine()
                .Split();
            CustomTuple<int, double> tupleThree = new CustomTuple<int, double>(int.Parse(inputThree[0]), double.Parse(inputThree[1]));

            Console.WriteLine(tupleOne.ToString());
            Console.WriteLine(tupleTwo.ToString());
            Console.WriteLine(tupleThree.ToString());
        }
    }

    public class CustomTuple<T, Y>
    {
        private T _item1;
        private Y _item2;

        public CustomTuple(T item1, Y item2)
        {
            _item1 = item1;
            _item2 = item2;
        }

        public override string ToString()
        {
            return $"{_item1} -> {_item2}";
        }
    }
}
