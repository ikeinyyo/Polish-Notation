using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PolishNotation.Test
{
    public class InfixConverterTest
    {
        [Theory]
        [InlineData("3 + 4", "3 4 +")]
        [InlineData("5 * 4 * 3 + 2", "5 4 * 3 * 2 +")]
        [InlineData("5 + 3 * 4 + 5 + 6 / 2", "5 3 4 * + 5 + 6 2 / +")]
        [InlineData("2 * 10 / 5", "2 10 * 5 /")]
        [InlineData("2 + 3 * 5 + 6 * 3 + 4 / 2 * 4 + 6", "2 3 5 * + 6 3 * + 4 2 / 4 * + 6 +")]
        [InlineData("4 + 5 * 4 * -3", "4 5 4 * -3 * +")]

        public void InfixToReversePolishNotationTest(string expression, string expected)
        {
            string result = PolishNotation.Core.ReversePolishNotation.FromInfix(expression);
            Assert.Equal(expected, result);
        }
    }
}
