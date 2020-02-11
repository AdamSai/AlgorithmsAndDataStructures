using System;

namespace Sorting
{
    public class Shell
    {
        /// <summary>
        /// Sorts an array much like insertion, but instead of swapping neighbors, it is swapping  
        /// elements with a gap size that is decreasing. We start with the biggest gap possible, then reduce by a multiplier
        /// until all elements have been sorted.
        /// </summary>
        /// <param name="a">An array of objects implementing the IComparable interface</param>
        public static void Sort(IComparable[] a)
        {
            Console.WriteLine("Sorting..");
            int N = a.Length;
            // h is the gap between the objects we are comparing
            int h = 1;
            while (h < N / 3) h = 3 * h + 1; // Calculate the biggest possible gap size
            while (h >= 1)
            {
                // h sort the array
                for (int i = h; i < N; i++)
                {
                    // if j is greater than the gap and value at j is lesser than it's index minus the gap, then execute
                    // and decrement by h (gap)
                    for (int j = i; j >= h && Less(a[j], a[j - h]); j -= h)
                    {
                        Exch(a, j, j - h);
                    }
                }
                // Adjust the gap size every time we increment i
                h /= 3;
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
        public static void Show(IComparable[] a)
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
        public static bool IsSorted(IComparable[] a)
        {
            for (var i = 1; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1])) return false;
            }

            return true;
        }
    }
}