using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PolishNotation.Test
{
    public class PolishNotationResolveTest
    {
        [Theory]
        [InlineData("+ 3 4", 7.0f)]
        [InlineData("- 5 * 6 7", -37.0f)]
        [InlineData("* - 5 6 7", -7.0f)]
        [InlineData("- * / 15 - 7 + 1 1 3 + 2 + 1 1", 5.0f)]
        [InlineData("- + - * 3 4 * 5 2 3 8", -3.0f)]
        [InlineData("- * 3 0 * 4 0", 0.0f)]
        [InlineData("+ + + + 2 * 3 5 * 6 3 * / 4 2 4 6", 49.0f)]
        public void PolishNotationResolve(string expression, float expected)
        {
            float result = PolishNotation.Core.PolishNotation.Resolve(expression);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("3 4 +", 7.0f)]
        [InlineData("5 6 7 * -", -37.0f)]
        [InlineData("5 6 - 7 *", -7.0f)]
        [InlineData("15 7 1 1 + - / 3 * 2 1 1 + + -", 5.0f)]
        [InlineData("3 4 * 5 2 * - 3 + 8 -", -3.0f)]
        [InlineData("3 0 * 4 0 * -", 0.0f)]
        [InlineData("2 3 5 * + 6 3 * + 4 2 / 4 * + 6 +", 49.0f)]
        public void ReversePolishNotationResolve(string expression, float expected)
        {
            float result = PolishNotation.Core.ReversePolishNotation.Resolve(expression);
            Assert.Equal(expected, result);
        }
    }
}
