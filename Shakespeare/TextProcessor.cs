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
        public string[] ProcessedStrings {  get; private set; }

        private static string ReadText(string path)
        {
            return File.ReadAllText(path);
        }

        public void ProcessTextFile(string path, string regexPattern)
        {
            var text = ReadText(path).ToLower();
            ProcessedStrings = SanitizeText(text, regexPattern);
        }

        private string[] SanitizeText(string text, string pattern)
        {
            var matches = Regex.Matches(text, pattern);
            var matchedStrings = new string[matches.Count()];
            for (var i = 0; i < matches.Count(); i++)
            {
                matchedStrings[i] = matches[i].ToString();
            }

            return matchedStrings;
        }
    }
}