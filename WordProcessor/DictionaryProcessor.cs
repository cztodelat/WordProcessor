using System;
using System.Collections.Generic;
using System.Text;
using WordProcessor.Models;

namespace WordProcessor
{
    public static class DictionaryProcessor
    {
        static List<WordModel> words = null;
        
        public static void ExecuteDictionary()
        {
            StringBuilder str = new StringBuilder();
            int nextChar;
            int lastCursorTopPosition = 0;

            while (true)
            {

                nextChar = Console.ReadKey().KeyChar;

                if (nextChar == 27 || (str.Length == 0 && nextChar == 13)) //27 Escape
                {
                    Console.Clear();
                    break;
                }
                else if (nextChar == 13) //13 Enter
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop + 1);
                    lastCursorTopPosition = Console.CursorTop;
                    ShowTopWords(5, str.ToString());
                    Console.SetCursorPosition(0, lastCursorTopPosition - 1);
                    str.Clear();
                }
                else
                {
                    str.Append((char)nextChar);
                }
            }
        }

        public static void ShowTopWords(int numberOfWords, string partOfWord)
        {
            if (words == null)
            {
                words = DataBaseProcessor.GetData(); 
                words.Sort((x, y) => WordModel.SortByWordThenByCount(x, y));
            }

            for (int i = 0; i < words.Count; i++)
            {
                if (numberOfWords == 0)
                {
                    break;
                }

                if (partOfWord.Equals(words[i].Word.Substring(0, partOfWord.Length), StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine($"{words[i].Word} - {words[i].Count}");
                    numberOfWords--;
                }

            }
        }
    }
}
