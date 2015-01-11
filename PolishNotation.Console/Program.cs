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
            System.Console.WriteLine(PolishNotation.Core.ReversePolishNotation.Resolve("3 7 2 * +"));
            System.Console.ReadLine();
        }
    }
}
