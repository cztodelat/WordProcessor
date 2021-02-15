using System.Collections.Generic;
using WordProcessor.Models;
using WordProcessor.Data;
using System.Linq;
using WordProcessor.Messages;

namespace WordProcessor
{
    public static class DataBaseProcessor
    {
        public static void InitializeDataBase()
        {
            using (WordProcessorContext context = new WordProcessorContext())
            {
                // Creates the database if not exists
                if (context.Database.EnsureCreated())
                {
                    DataBaseStandardMessages.CreateDataBeseMessage();
                }
            }
        }
        public static void SetNewData(IEnumerable<WordModel> words)
        {
            RemoveData();
            using (WordProcessorContext context = new WordProcessorContext())
            {
                foreach (WordModel word in words)
                {
                    if (IsWordApropriate(word))
                    {
                        context.Add(word);
                    }
                }

                context.SaveChanges();
            }

            DataBaseStandardMessages.CreateDataMessage();
        }

        public static void AddData(IEnumerable<WordModel> words)
        {
            using (WordProcessorContext context = new WordProcessorContext())
            {
                foreach (var word in words)
                {
                    var wordToUpdate = context.Words.Where(x => x.Word == word.Word).FirstOrDefault();

                    if (IsWordApropriate(word))
                    {
                        if (wordToUpdate is WordModel)
                        {
                            wordToUpdate.Count += word.Count;
                        }
                        else
                        {
                            context.Add(word);
                        }
                    }
                }

                context.SaveChanges();
            }
            DataBaseStandardMessages.UpdateDataMessage();


        }

        public static void RemoveData()
        {
            using (WordProcessorContext context = new WordProcessorContext())
            {
                context.Words.RemoveRange(GetData());
                //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Words', RESEED, 0)");
                context.SaveChanges();
            }
            DataBaseStandardMessages.RemoveDataMessage();
        }

        public static List<WordModel> GetData()
        {
            List<WordModel> words;

            using (WordProcessorContext context = new WordProcessorContext())
            {
                words = context.Words.ToList();
            }

            return words;
        }
        //Validation
        private static bool IsWordApropriate(WordModel word)
        {
            bool result = false;

            if (word.Word.Length >= 3 && word.Word.Length <= 15 && word.Count >= 3)
            {
                result = true;
            }

            return result;
        }
    }
}
