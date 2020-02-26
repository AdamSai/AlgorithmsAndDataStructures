using System;
using ClassExercises.PriorityQueues;

namespace ClassExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var charQueue = new LinkedPriorityQueue<char>();
            var intQueue = new LinkedPriorityQueue<int>();
            var intArray = new[] {50, 101, 1, 2, 4, 10, 1, 2, 100, 3, 1, 5, 10, 30, 50, 20, 10, 40, 70, 80, 100, 50};
            var charArray = new[] {'f', 'a', 'b', 'e', 't', 'd', 'v', 'e', 'b', 'e'};

            foreach (var c in charArray)
            {
                charQueue.Enqueue(c);
            }

            Console.Write("Char queue contents: ");
            while (!charQueue.IsEmpty())
            {
                Console.Write(charQueue.Dequeue() + " ");
            }

            Console.WriteLine();
            Console.Write("Int queue contents: ");

            foreach (var i in intArray)
            {
                intQueue.Enqueue(i);
            }

            while (!intQueue.IsEmpty())
            {
                Console.Write(intQueue.Dequeue() + " ");
            }
        }
    }
}