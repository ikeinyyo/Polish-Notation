using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishNotation.Core.Models
{
    public class Token
    {
        #region Private Const
        private const string TokenInvalidExceptionFormat = "Token '{0}' is invalid";
        private const string NotSupportedExceptionFormat = "Not supported operation for token type is '{0}'";

        #endregion
        public enum TokenType { Value, Operator, Expression }

        public string Text { get; set; }
        public TokenType Type { get; set; }


        public Token(string text)
        {
            Text = text;
            parseToken();
        }

        public Token(float value)
        {
            Text = value.ToString();
            Type = TokenType.Value;
        }

        public Token(IList<Token> tokens)
        {
            Text = string.Empty;
            Type = TokenType.Expression;

            if (tokens.Any())
            {
                Text = tokens.First().Text;
                foreach (var token in tokens.Skip(1))
                {
                    Text += string.Format(" {0}", token.Text);
                }
            }
        }

        public float GetResult(float value1, float value2)
        {
            float result = 0.0f;

            if(Type.Equals(TokenType.Operator))
            {
                switch (Text)
                {
                    case "+":
                        result = value1 + value2;
                        break;
                    case "-":
                        result = value1 - value2;
                        break;
                    case "*":
                        result = value1 * value2;
                        break;
                    case "/":
                        result = value1 / value2;
                        break;
                }
            }
            else
            {
                throw new NotSupportedException(string.Format(NotSupportedExceptionFormat, Type));

            }

            return result;
        }

        public float GetValue()
        {
            float value = 0.0f;

            if (Type.Equals(TokenType.Value))
            {
                try
                {
                    value = float.Parse(Text);
                    Type = TokenType.Value;
                }
                catch
                {
                    throw new ArgumentException(string.Format(TokenInvalidExceptionFormat, Text));
                }
            }
            else
            {
                throw new NotSupportedException(string.Format(NotSupportedExceptionFormat, Type));
            }

            return value;
        }

        #region Private Methods
        private void parseToken()
        {
            switch(Text)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    Type = TokenType.Operator;
                    break;
                default:
                    try
                    {
                        float.Parse(Text);
                        Type = TokenType.Value;
                    }
                    catch
                    {
                        throw new ArgumentException(string.Format(TokenInvalidExceptionFormat, Text));
                    }
                    break;
            }
        }
        #endregion
    }
}
