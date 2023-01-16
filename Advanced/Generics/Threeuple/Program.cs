using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();
            string city = input.Length == 5 ? input[3] + " " + input[4] : input[3];
            CustomTuple<string, string, string> tupleOne = new CustomTuple<string, string, string>(input[0] + " " + input[1], input[2], city);


            string[] inputTwo = Console.ReadLine()
                .Split();
            bool isDrunk = inputTwo[2] == "drunk" ? true : false;
            CustomTuple<string, int, bool> tupleTwo = new CustomTuple<string, int, bool>(inputTwo[0], int.Parse(inputTwo[1]), isDrunk);


            string[] inputThree = Console.ReadLine()
                .Split();
            CustomTuple<string, double, string> tupleThree = new CustomTuple<string, double, string>(inputThree[0], double.Parse(inputThree[1]), inputThree[2]);

            Console.WriteLine(tupleOne.ToString());
            Console.WriteLine(tupleTwo.ToString());
            Console.WriteLine(tupleThree.ToString());
        }
    }
    public class CustomTuple<T, Y, G>
    {
        private T _item1;
        private Y _item2;
        private G _item3;

        public CustomTuple(T item1, Y item2, G item3)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3; 
        }

        public override string ToString()
        {
            return $"{_item1} -> {_item2} -> {_item3}";
        }
    }
}
