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

            Console.Write("Sorting descending: ");
            arrSorter.SortDescending();
            foreach (var item in arrSorter.Queue)
            {
                Console.Write($"{item.ToString()} ");
            }


            Console.Write(("\n\nSorting ascending: "));
            arrSorter.SortAscending();
            foreach (var item in arrSorter.Queue)
            {
                Console.Write($"{item.ToString()} ");
            }

//            Console.Write("\n\nSorting using lambda: ");
//            arrSorter.Sort((x, y) => x.CompareTo(y) < 0);
//            foreach (var item in arrSorter.Queue)
//            {
//                Console.Write($"{item.ToString()} ");
//            }

            Console.Write("\n\nRemoving all elements: ");
            while (arrSorter.HeapSize > 0)
            {
                Console.Write($"\n Removing: {arrSorter.Dequeue().ToString()} \n New Array: ");
                foreach (var item in arrSorter.Queue)
                {
                    Console.Write(item.ToString() + " ");
                }
            }

            arrSorter.Enqueue(54);
            Console.WriteLine("Inserting 54");
            Console.WriteLine($"Dequeuing {arrSorter.Dequeue().ToString()}");
        }
    }
}