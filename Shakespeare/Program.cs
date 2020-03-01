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
            var regexPattern = @"[a-zA-ZæøåÆØÅ]+'?-?[a-zA-ZæøåÆØÅ]*";
            tp.ProcessTextFile("/home/adam/Documents/shakespeare-complete-works.txt", regexPattern);
            var stopwatch = Stopwatch.StartNew();
            ArraySorter<string> arraySorter = new ArraySorter<string>(tp.ProcessedStrings, tp.ProcessedStrings.Length);
            arraySorter.SortAscending();
            // Merge.Sort(tp.ProcessedStrings);
            // Trie.Sort(tp.ProcessedStrings);
            stopwatch.Stop();
            // for (var i = 0; i < 50 ; i++)
            // {
            //     Console.WriteLine(i + " " + tp.ProcessedStrings[i]);
            // }
            Console.WriteLine($"Sorted in {tp.ProcessedStrings.Length} strings in {stopwatch.Elapsed}");
        }
    }
}