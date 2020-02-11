using System;
using System.Diagnostics;

namespace Sorting
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var a = Console.ReadLine()?.Split(" ");
            Insertion.Sort(a);
            Debug.Assert(Selection.IsSorted(a));
            Insertion.Show(a);
        }
    }
}