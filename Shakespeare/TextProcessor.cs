using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Shakespeare
{
    public class TextProcessor
    {
        public string[] Words;
        private string[] bannedCharacters = new[] {",", ".", "/", ":", ";", "*", "\\", "(", ")", "#", "\n"};

        public TextProcessor()
        {
        }

        public string ReadText(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

        public void ProcessTextFile(string path)
        {
            var text = ReadText(path);
            text = text.ToLower();
            text = Regex.Replace(text, @"[^a-zA-Zæøå' -]+", "");
            text = Regex.Replace(text, @"(\s {1,}| - )", " ");
        
            Words = text.Split(' ');
        }
    }
}