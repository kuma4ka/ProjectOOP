using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Logic.interfaces
{
    public interface IPrintable
    {
        void PrintToConsole();

        void PrintToFile(string filePath);
    }
}