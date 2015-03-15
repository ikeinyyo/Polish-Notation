using PolishNotation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishNotation.Core
{
    public static class PolishNotationHelper
    {
        public const string MalformedExpresion = "Malformed expression: {0}";
        public static List<Token> ParseExpression(string expression)
        {
            List<Token> tokens = new List<Token>();
            var tokensStr = expression.Split(' ');

            foreach (var token in tokensStr)
            {
                tokens.Add(new Token(token));
            }

            return tokens;
        }
        public static string ExpressionToString(List<Token> tokens)
        {
            return ExpressionToString(tokens, false);
        }

        public static string ExpressionToString(List<Token> tokens, bool separator)
        {
            string expression = string.Empty;
            string format = string.Empty;

            if(separator)
            {
                format = "{0} | ";
            }
            else
            {
                format = "{0} ";
            }

            foreach (var token in tokens)
            {
                expression += string.Format(format, token.Text);
            }

            return expression;
        }

    }


}
