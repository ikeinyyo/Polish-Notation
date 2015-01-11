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
        #endregion
        public enum TokenType { Value, Operator, Expression }

        public string Text { get; set; }
        public TokenType Type { get; set; }


        public Token(string text)
        {
            Text = text;
            parseToken();
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
                    Text += token.Text;
                }
            }
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
                        throw new ArgumentException(string.Format(TokenInvalidExceptionFormat, Text))
                    }
                    break;
            }
        }
        #endregion
    }
}
