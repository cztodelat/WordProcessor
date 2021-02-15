using System;
using System.Collections.Generic;
using System.Text;

namespace WordProcessor.Messages
{
    public static class DataBaseStandardMessages
    {
        public static void CreateDataMessage()
        {
            Console.WriteLine("The new data has been created!");
        }

        public static void UpdateDataMessage()
        {
            Console.WriteLine("The data has been changed!");
        }

        public static void RemoveDataMessage()
        {
            Console.WriteLine("The data has been removed!");
        }

        public static void CreateDataBeseMessage()
        {
            Console.WriteLine("Data base has been created!");
        }
    }
}
