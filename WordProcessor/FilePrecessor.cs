using System.IO;
using System.Collections.Generic;
using WordProcessor.Models;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using System.Text;
using WordProcessor.Messages;

namespace WordProcessor
{
    public static class FilePrecessor
    {
        public static List<WordModel> GetWordsFromFile(string path)
        {
            List<WordModel> result = new List<WordModel>();
            string[] text;
            IEnumerable<string> words;
            int cout = 0;

            //Delete all special characters
            text = Regex.Replace(File.ReadAllText(path).ToLower(), @"[^0-9a-zA-Z' ]+", "").Split(" ");

            words = text.Distinct();

            foreach (string word in words)
            {
                cout = text.Count(x => x == word);
                result.Add(new WordModel { Word = word, Count = cout });
            }

            return result;
        }

        public static string GetFilePath()
        {
            FileStandardMessages.AskForPathMessage();
            string path = Console.ReadLine();
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Could not find file '{Path.GetFullPath(path)}'");
            }

            if (GetFileEncoding(path) != Encoding.UTF8)
            {
                throw new ArgumentException("The incoming file must be in UTF-8 encoding!");
            }
            return path;
        }
    
        private static Encoding GetFileEncoding (string path)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe && bom[2] == 0 && bom[3] == 0) return Encoding.UTF32; //UTF-32LE
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return new UTF32Encoding(true, true);  //UTF-32BE

            // We actually have no idea what the encoding is if we reach this point, so
            // you may wish to return null instead of defaulting to ASCII
            return Encoding.ASCII;
        }
    }
}
