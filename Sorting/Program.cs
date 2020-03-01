using System;
using System.Diagnostics;

namespace Sorting
{
    public class Program
    {
        public static void Main(String[] args)
        {
            // var a = Console.ReadLine()?.Split(" ");
            //     Shell.Sort(a);
            // // Debug.Assert(Selection.IsSorted(a));
            // Shell.Show(a);
            //
            // Console.WriteLine("Select first algorithm");
            // String alg1 = Console.ReadLine();
            // Console.WriteLine("Select second algorithm");
            // String alg2 = Console.ReadLine();
            // Console.WriteLine("Select amount size of arrays");
            // int N = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Input must be a number"));
            // Console.WriteLine("Select amount of arrays");
            // int T = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Input must be a number"));
            // var t1 = SortCompare.TimeRandomInput(alg1, N, T); // total for alg1
            // var t2 = SortCompare.TimeRandomInput(alg2, N, T); // total for alg2
            // var multiplier = t2 / t1;
            // Console.WriteLine($"For {N} random Doubles\n{alg1} is");
            // Console.WriteLine($"{multiplier:N1} times faster than {alg2}\n");
            var input = new[]
            {
                10, 14, 19, 26, 31, 42, 27, 44, 35, 33
            };
            var arrSorter = new ArraySorter<int>(input, 20);
            arrSorter.SortAscending();

            Console.Write("Ascending: ");
            foreach (var item in arrSorter.Queue)
            {
                Console.Write(item + " ");
            }

            arrSorter.SortDescending();
            Console.Write("\nDescending: ");
            foreach (var item in arrSorter.Queue)
            {
                Console.Write(item + " ");
            }

            arrSorter.Enqueue(25);
            arrSorter.Enqueue(50);
            arrSorter.Enqueue(13);
            arrSorter.Enqueue(18);
            arrSorter.Enqueue(80);
            Console.Write("\n============After Insert ===========");
            Console.Write("\nAfter insert min heapify: ");
            foreach (var item in arrSorter.Queue)
            {
                Console.Write(item + " ");
            }

            arrSorter.SortAscending();
            Console.Write("\nAscending: ");

            foreach (var item in arrSorter.Queue)
            {
                Console.Write(item + " ");
            }

            arrSorter.SortDescending();
            Console.Write("\nDescending: ");
            foreach (var item in arrSorter.Queue)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nDequeued " + arrSorter.Dequeue());
            Console.Write("After dequeue: ");
            foreach (var item in arrSorter.Queue)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nDequeued " + arrSorter.Dequeue());
        }
    }
}