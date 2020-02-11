using System;
using System.Diagnostics;

namespace Sorting
{
    public class SortCompare
    {
        public static double Time(String alg, IComparable[] a)
        {
            var stopwatch = Stopwatch.StartNew();
            if (alg.Equals("Insertion")) Insertion.Sort(a);
            if (alg.Equals("Selection")) Selection.Sort(a);
            if (alg.Equals("Shell")) Shell.Sort(a);
            stopwatch.Stop();
            return stopwatch.Elapsed.Milliseconds;
        }

        public static double TimeRandomInput(string alg, int N, int T)
        {
            // use alg to sort T random arrays of length N
            double total = 0;
            var a = new IComparable[N];
            var random = new Random();
            for (int t = 0; t < T; t++)
            {
                // Perform one experiment (generate and sort an array).
                for (int i = 0; i < N; i++)
                {
                    a[i] = random.NextDouble();
                }

                total += Time(alg, a);
            }

            return total;
        }
    }
}