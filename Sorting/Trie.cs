using System;
using System.Diagnostics;
using System.Linq;

namespace Sorting
{
    public class Trie
    {

        public static void Sort(string[] str)
        {
            var root = new TrieNode();
            var stopWatch = Stopwatch.StartNew();
            foreach (var s in str)
            {
                TrieNode.Insert(root, s, s);
            }

            stopWatch.Stop();
            TrieNode.printTrie(root);
            Console.WriteLine($"Inserted all {str.Length} elements in {stopWatch.ElapsedMilliseconds}ms");
        }


        private class TrieNode
        {
            public TrieNode[] children;

            private string _value;

            // value of the node

            // Value used to store string if array only has this value

            public TrieNode()
            {
                children = new TrieNode[28];
            }

            public static void Insert(TrieNode node, string str, string value)
            {
                foreach (var c in str)
                {
                    var currentIndex = GetHashValue(c);
                    var childNode = node.children[currentIndex];
                    // If the current character does not exist in the array, insert it
                    if (childNode == null)
                    {
                        node.children[currentIndex] = new TrieNode();
                    }

                    // Move to the next child
                    node = node.children[currentIndex];
                }

                node._value = value;
            }

            public static void printTrie(TrieNode node)
            {
                if (node == null) return;
                if (!string.IsNullOrEmpty(node._value))
                    Console.WriteLine(node._value);
                // here you can play with the order of the children
                foreach (var child in node.children)
                {
                        printTrie(child);
                }
            }

            private static int GetHashValue(char c)
            {
                // Return 26 if char is -
                // Return 27 if char is '
                // Default return value is char - 97
                return c switch
                {
                    '-' => 26,
                    '\'' => 27,
                    _ => c - 97
                };
            }
        }
    }
}