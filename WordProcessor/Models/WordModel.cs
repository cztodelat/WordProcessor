using System.ComponentModel.DataAnnotations;

namespace WordProcessor.Models
{
    public class WordModel
    {
        [Key]
        public int WordId { get; set; }
        public string Word { get; set; }
        public int Count { get; set; }

        public static int SortByWordThenByCount(WordModel wm1, WordModel wm2)
        {
            int result = wm2.Count.CompareTo(wm1.Count);

            if (result == 0)
            {
                result = wm1.Word.CompareTo(wm2.Word);
            }

            return result;
        }
    }
}
