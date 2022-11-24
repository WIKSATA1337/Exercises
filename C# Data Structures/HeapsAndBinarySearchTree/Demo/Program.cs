using System;
using _01.BinaryTree;
using _02.BinarySearchTree;
using _03.MaxHeap;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // BinaryTree Testing
            //PreOrderTest();
            //ForEachInOrderTest();
        }

        static void ForEachInOrderTest()
        {
            var tree = new BinaryTree<int>(
                        17,
                        new BinaryTree<int>(
                            9,
                            new BinaryTree<int>(3, null, null),
                            new BinaryTree<int>(11, null, null)
                        ),
                        new BinaryTree<int>(
                            25,
                            new BinaryTree<int>(20, null, null),
                            new BinaryTree<int>(31, null, null)
                        ));

            string expected = "3 9 11 17 20 25 31";
            Console.WriteLine(string.Join(" ", expected));

            tree.ForEachInOrder(t => Console.Write(t + " "));
        }

        static void PreOrderTest()
        {
            BinaryTree<int> bt = new BinaryTree<int>(1,
                                        new BinaryTree<int>(2,
                                            new BinaryTree<int>(4, null, null),
                                            new BinaryTree<int>(5, null, null)),
                                        new BinaryTree<int>(3,
                                            new BinaryTree<int>(6, null, null),
                                            new BinaryTree<int>(7, null, null)));

            var result = bt.PreOrder();
            foreach (var subtree in result)
            {
                Console.WriteLine(string.Join(" ", subtree.Value));
            }
        }
    }
}