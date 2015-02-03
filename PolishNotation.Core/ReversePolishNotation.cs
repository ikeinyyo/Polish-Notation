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
            List<Token> tokens = PolishNotationHelper.parseExpression(expression);

            Stack<Token> values = new Stack<Token>();

            try
            {

                foreach (var token in tokens)
                {
                    if (token.Type.Equals(Token.TokenType.Value))
                    {
                        values.Push(token);
                    }
                    else if (token.Type.Equals(Token.TokenType.Operator))
                    {
                        Token second = values.Pop();
                        Token first = values.Pop();
                        float result = token.GetResult(first.GetValue(), second.GetValue());
                        values.Push(new Token(result));
                    }
                }
            }
            catch
            {
                throw new Exception(string.Format(PolishNotationHelper.MalformedExpresion, expression));
            }

            if(values.Count.Equals(1))
            {
                value = values.Pop().GetValue();
            }
            else
            {
                throw new Exception(string.Format(PolishNotationHelper.MalformedExpresion, expression));
            }
            
            return value;
        }

        public static string Reverse(string expression)
        {
            string reverse = string.Empty;
            List<Token> tokens = PolishNotationHelper.parseExpression(expression);

            Stack<Token> expressions = new Stack<Token>();

            try
            {

                foreach (var token in tokens)
                {
                    if (token.Type.Equals(Token.TokenType.Value) || token.Type.Equals(Token.TokenType.Expression))
                    {
                        expressions.Push(token);
                    }
                    else if (token.Type.Equals(Token.TokenType.Operator))
                    {
                        Token second = expressions.Pop();
                        Token first = expressions.Pop();
                        expressions.Push(new Token(new List<Token>() { token, first, second }));
                    }
                }
            }
            catch
            {
                throw new Exception(string.Format(PolishNotationHelper.MalformedExpresion, expression));
            }

            if (expressions.Count.Equals(1))
            {
                reverse = expressions.Pop().Text;
            }
            else
            {
                throw new Exception(string.Format(PolishNotationHelper.MalformedExpresion, expression));
            }

            return reverse;
        }
    }
}
