using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishNotation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(PolishNotation.Core.PolishNotation.Resolve("+ 3 4"));
        }
    }
}
