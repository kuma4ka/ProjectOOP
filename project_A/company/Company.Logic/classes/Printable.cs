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
        public void PrintToConsole()
        {
            throw new NotImplementedException();
        }

        public void PrintToFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}