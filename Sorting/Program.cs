using System;
using System.Diagnostics;

namespace Sorting
{
    public class Program
    {
        public static void Main(String[] args)
        {
            // var a = Console.ReadLine()?.Split(" ");
            // Insertion.Sort(a);
            // Debug.Assert(Selection.IsSorted(a));
            // Insertion.Show(a);
            
            Console.WriteLine("Select first algorithm");
            String alg1 = Console.ReadLine();
            Console.WriteLine("Select second algorithm");
            String alg2 = Console.ReadLine();
            Console.WriteLine("Select amount size of arrays");
            int N = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Input must be a number"));
            Console.WriteLine("Select amount of arrays");
            int T = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Input must be a number"));
            var t1 = SortCompare.TimeRandomInput(alg1, N, T); // total for alg1
            var t2 = SortCompare.TimeRandomInput(alg2, N, T); // total for alg2
            var multiplier = t2 / t1;
            Console.WriteLine($"For {N} random Doubles\n{alg1} is");
            Console.WriteLine($"{multiplier:N1} times faster than {alg2}\n");
        }
    }
}