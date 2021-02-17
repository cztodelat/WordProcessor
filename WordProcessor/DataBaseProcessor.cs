using System.Collections.Generic;
using WordProcessor.Models;
using WordProcessor.Data;
using System.Linq;
using WordProcessor.Messages;
using System.Threading.Tasks;
using System;

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
        public async static Task SetNewData(IEnumerable<WordModel> words)
        {
            await RemoveDataAsync();
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

        public async static Task RemoveDataAsync()
        {
            using (WordProcessorContext context = new WordProcessorContext())
            {
                var data = await GetDataAsync();
                context.Words.RemoveRange(data);
                //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Words', RESEED, 0)");
                context.SaveChanges();
            }
            DataBaseStandardMessages.RemoveDataMessage();
        }

        public async static Task<List<WordModel>> GetDataAsync()
        {
            return await Task.Run(() => GetData());
        }

        private static List<WordModel> GetData()
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
