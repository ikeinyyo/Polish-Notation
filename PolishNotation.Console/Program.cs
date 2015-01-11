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
            try
            {
                string expressionRPN = "7 4 4 * +";
                string expressionPN = "+ * 4 4 7";
                System.Console.WriteLine(string.Format("Reverse Polish Notation expression: {0}", expressionRPN));
                System.Console.WriteLine(PolishNotation.Core.ReversePolishNotation.Resolve(expressionRPN));

                System.Console.WriteLine(string.Format("Polish Notation expression: {0}", expressionPN));
                System.Console.WriteLine(PolishNotation.Core.PolishNotation.Resolve(expressionPN));
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            System.Console.ReadLine();
        }
    }
}
