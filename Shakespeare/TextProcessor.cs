using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Shakespeare
{
    public class TextProcessor
    {
        public string[] Words {  get; private set; }

        private static string ReadText(string path)
        {
            return File.ReadAllText(path);
        }

        public void ProcessTextFile(string path)
        {
            var text = ReadText(path).ToLower();
            text = SanitizeText(text);
            // Initialize the Words array to the sanitized text.
            Words = text.Split(' ').Where(word => !word.Equals(string.Empty)).ToArray();
            Console.WriteLine(Words.Length);
        }

        private static string SanitizeText(string text)
        {
            // Remove everything that doesn't match a word character and single quotation mark.
            text = Regex.Replace(text, @"[^a-zA-ZæøåÆØÅ' ]+", " ");
            // Remove all single quotation marks that are either:
            // Lead by whitespace or special characters
            // OR Followed by whitespace or special characters
            text = Regex.Replace(text, @"(\s|[^a-zA-ZæøåÆØÅ])'{1,}|'{1,}(\s|[^a-zA-ZæøåÆØÅ])", " ");
            return text;
        }
    }
}