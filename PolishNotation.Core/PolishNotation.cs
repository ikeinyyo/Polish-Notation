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
            List<Token> tokens = PolishNotationHelper.ParseExpression(expression);
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
            List<Token> tokens = PolishNotationHelper.ParseExpression(expression);
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

        public static string FromInfix(string expression)
        {
            string reverse = string.Empty;
            List<Token> tokens = PolishNotationHelper.ParseExpression(expression);
            Stack<Token> values = new Stack<Token>();
            Stack<Token> operators = new Stack<Token>();

            List<List<string>> operandsGroups = new List<List<string>>();
            operandsGroups.Add(new List<string>() { "*", "/" });
            operandsGroups.Add(new List<string>() { "+", "-" });

            foreach (var operands in operandsGroups)
            {
                bool changes = false;
                do
                {
                    changes = false;
                    operators.Clear();
                    values.Clear();

                    foreach (var token in tokens)
                    {
                        if (token.Type.Equals(Token.TokenType.Operator) && operands.Contains(token.Text))
                        {
                            operators.Push(token);
                        }
                        else if (token.Type.Equals(Token.TokenType.Value) || token.Type.Equals(Token.TokenType.Expression))
                        {
                            if (operators.Count == 0)
                            {
                                values.Clear();
                            }
                            values.Push(token);
                        }

                        if (operators.Count >= 1 && values.Count >= 2)
                        {
                            Token op = operators.Pop();
                            Token second = values.Pop(); // Value 1
                            Token first = values.Pop(); // Value 2

                            int index = tokens.IndexOf(first);
                            tokens.Remove(op);
                            tokens.Remove(first);
                            tokens.Remove(second);
                            Token result = new Token(new List<Token>() { op, first, second });
                            if (tokens.Count > index)
                            {
                                tokens.Insert(index, result);
                            }
                            else
                            {
                                tokens.Add(result);
                            }
                            changes = true;
                            break;
                        }
                    }

                } while (!tokens.Count.Equals(1) && changes);
            }

            if (tokens.Count.Equals(1))
            {
                reverse = tokens.First().Text;
            }
            else
            {
                throw new Exception(string.Format(PolishNotationHelper.MalformedExpresion, expression));
            }

            return reverse;
        }
    }
}
