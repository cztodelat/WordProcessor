using System;
using System.IO;

namespace WordProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DataBaseProcessor.InitializeDataBase();
                AppProcessor.ExecuteApp(args);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Try again!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}
