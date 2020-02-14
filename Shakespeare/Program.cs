using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Sorting;

namespace Shakespeare
{
    class Program
    {
        static void Main(string[] args)
        {
            var tp = new TextProcessor();
            tp.ProcessTextFile("/home/adam/Documents/shakespeare-complete-works.txt");
            var stopwatch = Stopwatch.StartNew();
            Shell.Sort(tp.Words);
            stopwatch.Stop();
            for (var i = 0; i < 50 ; i++)
            {
                Console.WriteLine(i + " " + tp.Words[i]);
            }
            Console.WriteLine($"Sorted in {stopwatch.Elapsed}");
        }
    }
}