﻿using PolishNotation.Core.Models;
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
                        Token value1 = values.Pop(); // Value 1
                        Token value2 = values.Pop(); // Value 2
                   
                        int index = tokens.IndexOf(op);
                        tokens.Remove(op);
                        tokens.Remove(value1);
                        tokens.Remove(value2);
                        float result = op.GetResult(value1.GetValue(), value2.GetValue());
                        tokens.Insert(index, new Token(result));
                        changes = true;
                        break;
                    }
                }

            } while (!tokens.Count.Equals(1) && changes);

            value = tokens.First().GetValue();

            return value;
        }
    }
}
