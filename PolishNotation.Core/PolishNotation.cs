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

            bool changes = false;
            do
            {
                changes = false;
                Token op = null; // Operator
                Token value1 = null; // Value 1
                Token value2 = null; // Value 2

                foreach (var token in tokens)
                {
                    if(token.Type.Equals(Token.TokenType.Operator))
                    {
                        op = token;
                        value1 = value2 = null;
                    }
                    else if (op != null && value1 == null && token.Type.Equals(Token.TokenType.Value))
                    {
                        value1 = token;
                        value2 = null;
                    }
                    else if (op != null && value1 != null && value2 == null && token.Type.Equals(Token.TokenType.Value))
                    {
                        value2 = token;
                        int index = tokens.IndexOf(op);
                        tokens.Remove(op);
                        tokens.Remove(value1);
                        tokens.Remove(value2);
                        float result = op.GetResult(value1.GetValue(), value2.GetValue());
                        tokens.Insert(index, new Token(result));
                        changes = true;
                        break;
                    }
                    else
                    {
                        op = value1 = value2 = null;
                    }
                }

            } while (!tokens.Count.Equals(1) && changes);

            value = tokens.First().GetValue();

            return value;
        }
    }
}
