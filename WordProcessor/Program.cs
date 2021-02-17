using System;
using System.IO;
using System.Threading.Tasks;

namespace WordProcessor
{


    class Program
    {
        static async Task Main(string[] args)
        {
            #region WordProcessor Starter
            try
            {
                DataBaseProcessor.InitializeDataBase();
                await AppProcessor.ExecuteApp(args);
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
            #endregion




        }
    }
}
