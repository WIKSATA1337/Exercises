using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            Lake lake = new Lake(input);

            string result = "";
            foreach (var item in lake)
            {
                result += item + ", ";
            }
            result = result.Substring(0, result.Length - 2);
            Console.WriteLine(result);
        }
    }

    public class Lake : IEnumerable<int>
    {
        private List<int> stones;
        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            //return new LakeEnumerator(stones);
            for (int i = 0; i < stones.Count; i+=2)
            {
                yield return stones[i];
            }
            int oddEven = stones.Count % 2 == 0 ? 1 : 2;
            for (int i = stones.Count - oddEven; i >= 0; i-=2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class LakeEnumerator : IEnumerator<int>
    {
        private List<int> lakeStones;
        private int index = -1;
        public LakeEnumerator(List<int> lakeStones)
        {
            this.lakeStones = lakeStones;
        }

        public int Current => lakeStones[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++index < lakeStones.Count;
        }

        public void Reset()
        {
        }
    }
}
