using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Sorting
{
    //Top down merge sort
    public class Merge
    {
        private static IComparable[] aux;

        /// <summary>
        /// Copies array a into auxiliary array
        /// </summary>
        /// <param name="a">An array of objects implementing the IComparable interface</param>
        public static void Sort(IComparable[] a)
        {
            aux = new IComparable[a.Length];
            Sort(a, 0, a.Length - 1);
        }
        /// <summary>
        /// Sort array a by first sorting the left half, then the right half, and finally mergin the two into a single array.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        private static void Sort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            var mid = lo + (hi - lo) / 2;
            Sort(a, lo, mid); // sort left half
            Sort(a, mid + 1, hi); // sort right half
            MergeArray(a, lo, mid, hi); // merge arrays
        }

        /// <summary>
        /// This method merges by first copying into the auxiliary array aux[] then merging back to a[] . In the
        /// merge (the second for loop), there are four conditions: left half exhausted (take from the right), right
        /// half exhausted (take from the left), current key on right less than current key on left (take from the
        /// right), and current key on right greater than or equal to current key on left (take from the left).
        /// </summary>
        /// <param name="a"></param>
        /// <param name="lo"></param>
        /// <param name="mid"></param>
        /// <param name="hi"></param>
        private static void MergeArray(IComparable[] a, in int lo, in int mid, in int hi)
        {
            int i = lo, j = mid + 1;
            for (var k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            for (var k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (Less(aux[j], aux[i])) a[k] = aux[j++];
                else a[k] = a[i++];
            }
        }

        /// <summary>
        /// Check if v is less than w
        /// </summary>
        /// <param name="v">The first value to compare</param>
        /// <param name="w">The second value to compare</param>
        /// <returns>Returns <c>true</c> if v is smaller than w else <c>false</c></returns>
        private static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        /// <summary>
        /// Swap index of values at position i and j
        /// </summary>
        /// <param name="a">The array in which i and j are contained</param>
        /// <param name="i">The first value with the index to be swapped</param>
        /// <param name="j">The second value with the index to be swapped</param>
        private static void Exch(IComparable[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        /// <summary>
        /// Prints the contents of an array
        /// </summary>
        /// <param name="a">The array of the contents that should be printed</param>
        internal static void Show(IComparable[] a)
        {
            foreach (var t in a)
            {
                Console.Write(t + " ");
            }
        }

        /// <summary>
        /// Check if the array is sorted
        /// </summary>
        /// <param name="a">The array which you want to check if it is sorted</param>
        /// <returns>Return <c>true</c> if the array is sorted otherwise <c>false</c></returns>
        internal static bool IsSorted(IComparable[] a)
        {
            for (var i = 1; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1])) return false;
            }

            return true;
        }
    }
}