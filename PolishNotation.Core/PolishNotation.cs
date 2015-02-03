using PolishNotation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishNotation.Core
{
    public class PolishNotation
    {
        public static float Resolve(string expression)
        {
            float value = 0.0f;
            List<Token> tokens = PolishNotationHelper.parseExpression(expression);
            Stack<Token> operators = new Stack<Token>();
            Stack<Token> values = new Stack<Token>();

            bool changes = false;
            do
            {
                changes = false;

                foreach (var token in tokens)
                {

                    if(token.Type.Equals(Token.TokenType.Operator))
                    {
                        operators.Push(token);
                        values.Clear();
                    }
                    else if (token.Type.Equals(Token.TokenType.Value))
                    {
                        values.Push(token);
                    }

                    if (operators.Count >= 1 && values.Count >= 2)
                    {
                        Token op = operators.Pop();
                        Token second = values.Pop(); // Value 1
                        Token first = values.Pop(); // Value 2
                   
                        int index = tokens.IndexOf(op);
                        tokens.Remove(op);
                        tokens.Remove(first);
                        tokens.Remove(second);
                        float result = op.GetResult(first.GetValue(), second.GetValue());
                        tokens.Insert(index, new Token(result));
                        changes = true;
                        break;
                    }
                }

            } while (!tokens.Count.Equals(1) && changes);

            value = tokens.First().GetValue();

            return value;
        }

        public static string Reverse(string expression)
        {
            string reverse = string.Empty;
            List<Token> tokens = PolishNotationHelper.parseExpression(expression);
            Stack<Token> operators = new Stack<Token>();
            Stack<Token> expressions = new Stack<Token>();

            bool changes = false;
            do
            {
                changes = false;

                foreach (var token in tokens)
                {

                    if (token.Type.Equals(Token.TokenType.Operator))
                    {
                        operators.Push(token);
                        expressions.Clear();
                    }
                    else if (token.Type.Equals(Token.TokenType.Value) || token.Type.Equals(Token.TokenType.Expression))
                    {
                        expressions.Push(token);
                    }

                    if (operators.Count >= 1 && expressions.Count >= 2)
                    {
                        Token op = operators.Pop();
                        Token second = expressions.Pop(); // Value 1
                        Token first = expressions.Pop(); // Value 2

                        int index = tokens.IndexOf(op);
                        tokens.Remove(op);
                        tokens.Remove(first);
                        tokens.Remove(second);
                        tokens.Insert(index, new Token(new List<Token>() { first, second, op }));
                        changes = true;
                        break;
                    }
                }

            } while (!tokens.Count.Equals(1) && changes);

            reverse = tokens.First().Text;

            return reverse;
        }
    }
}
