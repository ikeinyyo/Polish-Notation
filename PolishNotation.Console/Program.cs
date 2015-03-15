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
                string expressionPN = "- * / 15 - 7 + 1 1 3 + 2 + 1 1";
                string Reverse = "5 1 2 + 4 * + 3 -";
                string Reverse2 = "6 4 5 + * 25 2 3 + / -";
                string Infix1 = "3 + 4";
                string Infix2 = "5 + 3 * 4 + 5 + 6 / 2";
                string Infix3 = "2 + 3 * 5 + 6 * 3 + 4 / 2 * 4 + 6";

                System.Console.WriteLine(string.Format("Reverse Polish Notation expression: {0}", expressionRPN));
                System.Console.WriteLine(PolishNotation.Core.ReversePolishNotation.Resolve(expressionRPN));

                System.Console.WriteLine(string.Format("Polish Notation expression: {0}", expressionPN));
                System.Console.WriteLine(PolishNotation.Core.PolishNotation.Resolve(expressionPN));

                System.Console.WriteLine(string.Format("Reverse Polish Notation expression: {0}", Reverse));
                System.Console.WriteLine(PolishNotation.Core.ReversePolishNotation.Resolve(Reverse));
                System.Console.WriteLine(PolishNotation.Core.ReversePolishNotation.Reverse(Reverse));
                System.Console.WriteLine(PolishNotation.Core.PolishNotation.Resolve(PolishNotation.Core.ReversePolishNotation.Reverse(Reverse)));

                System.Console.WriteLine(string.Format("Reverse Polish Notation expression: {0}", Reverse2));
                System.Console.WriteLine(PolishNotation.Core.ReversePolishNotation.Resolve(Reverse2));
                System.Console.WriteLine(PolishNotation.Core.ReversePolishNotation.Reverse(Reverse2));
                System.Console.WriteLine(PolishNotation.Core.PolishNotation.Resolve(PolishNotation.Core.ReversePolishNotation.Reverse(Reverse2)));
                System.Console.WriteLine(PolishNotation.Core.PolishNotation.Reverse(PolishNotation.Core.ReversePolishNotation.Reverse(Reverse2)));
                
                
                System.Console.WriteLine(PolishNotation.Core.ReversePolishNotation.FromInfix(Infix1));
                System.Console.WriteLine(PolishNotation.Core.ReversePolishNotation.FromInfix(Infix2));
                System.Console.WriteLine(PolishNotation.Core.ReversePolishNotation.FromInfix(Infix3));

                System.Console.WriteLine(PolishNotation.Core.PolishNotation.Reverse("- + - * 3 4 * 5 2 3 8"));
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            System.Console.ReadLine();
        }
    }
}
