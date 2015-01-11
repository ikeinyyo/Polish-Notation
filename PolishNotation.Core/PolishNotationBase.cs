using PolishNotation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishNotation.Core
{
    public class PolishNotationBase
    {
        protected const string MalformedExpresion = "Malformed expression: {0}";
        protected static List<Token> parseExpression(string expression)
        {
            List<Token> tokens = new List<Token>();
            var tokensStr = expression.Split(' ');

            foreach (var token in tokensStr)
            {
                tokens.Add(new Token(token));
            }

            return tokens;
        }
    }
}
