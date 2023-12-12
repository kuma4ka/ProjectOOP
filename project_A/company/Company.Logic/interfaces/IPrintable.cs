using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Logic.interfaces
{
    public interface IPrintable
    {
        public void PrintToConsole();

        void PrintToFileTXT(string filePath);
    }
}