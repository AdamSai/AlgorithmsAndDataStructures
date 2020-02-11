using System;
using System.Diagnostics;

namespace Sorting
{
    public class Selection
    {
        // Sort the array by replacing 
        public static void Sort(IComparable[] a)
        {
            var N = a.Length;
            for (var i = 0; i < N; i++)
            {
                // Find the smallest value in the array and replace a[i] with said value
                var min = i;
                for (var j = i + 1 ; j < N; j++)
                {
                    if (Less(a[j], a[min])) min = j;
                }
                Exch(a, i, min);
            }
        }

        // Check if v is less than w
        private static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }
        
        // Exchange values at position i and j
        private static void Exch(IComparable[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        // Print contents of the array
        private static void Show(IComparable[] a)
        {
            foreach (var t in a)
            {
                Console.Write(t + " ");
            }
        }

        private static bool IsSorted(IComparable[] a)
        {
            for (var i = 1; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1])) return false;
            }
            return true;
        }
        
        public static void Main(String[] args)
        { // Read strings from standard input, sort them, and print.
            String[] a = Console.ReadLine().Split(" ");
            Sort(a);
            Debug.Assert(IsSorted(a));
            Show(a);
        }
        
    }
}