using Company.Logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Company.Logic.classes
{
    internal class PrintableClass : IPrintable
    {
        public IPrintable IPrintable
        {
            get => default;
            set
            {
            }
        }

        public void PrintToConsole()
        {
            Console.WriteLine("Printing to console...");
        }

        public void PrintToFileTXT(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Printing to text file...");
                }
                Console.WriteLine($"Printed to file: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while printing to file: {ex.Message}");
            }
        }
    }
}