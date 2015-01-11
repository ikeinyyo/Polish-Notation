using PolishNotation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishNotation.Core
{
    public class ReversePolishNotation
    {
        public static float Resolve(string expression)
        {
            float value = 0.0f;
            List<Token> tokens = parseExpression(expression);

            Stack<Token> values = new Stack<Token>();

            foreach (var token in tokens)
            {
                if (token.Type.Equals(Token.TokenType.Value))
                {
                    values.Push(token);
                }
                else if (token.Type.Equals(Token.TokenType.Operator))
                {
                    Token value1 = values.Pop();
                    Token value2 = values.Pop();
                    float result = token.GetResult(value1.GetValue(), value2.GetValue());
                    values.Push(new Token(result));
                }
            }

            value = values.Pop().GetValue();
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
