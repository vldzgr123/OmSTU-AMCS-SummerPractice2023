using Xunit;
using SquareEquationLib;

namespace SquareEquation_Test
{
    public class SquareEquation_Test
    {
        [Theory]
        [InlineData(double.NaN,1,1)]
        [InlineData(1,double.NaN,1)]
        [InlineData(1,1,double.NaN)]

        [InlineData(double.PositiveInfinity,1,1)]
        [InlineData(1,double.PositiveInfinity,1)]
        [InlineData(1,1,double.PositiveInfinity)]

        [InlineData(double.NegativeInfinity,1,1)]
        [InlineData(1,double.NegativeInfinity,1)]
        [InlineData(1,1,double.NegativeInfinity)]

        public void ThrowError(double a,double b, double c)
        {
            Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
        }

        [Theory]
        [InlineData(1, 6, 9, new double[]{-3})]
        [InlineData(10, 2, 10, new double[] {})]
        [InlineData(1,2,-3, new double[] {1, -3})]
        [InlineData(1, 0, 1, new double[]{})]
        [InlineData(1, 4, 5, new double[]{})]

        public void noThrowError(double a, double b, double c, double[] expected)
        {
            var result=SquareEquation.Solve(a,b,c);
            Array.Sort(result);
            Array.Sort(expected);

            if (expected.Length != result.Length)
            {
                Assert.Fail("Amount of roots does not match");
            }

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], result[i], 5);
            }
        }
    }
}