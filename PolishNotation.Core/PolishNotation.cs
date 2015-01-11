using PolishNotation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishNotation.Core
{
    public static class PolishNotation
    {
        public static float Resolve(string expression)
        {
            float value = 0.0f;
            List<Token> tokens = parseExpression(expression);


            return value;
        }


        #region Private Methods
        private static List<Token> parseExpression(string expression)
        {
            List<Token> tokens = new List<Token>();
            var tokensStr = expression.Split(' ');

            foreach (var token in tokensStr)
            {
                tokens.Add(new Token(token));
            }

            return tokens;
        }
        #endregion
    }
}
