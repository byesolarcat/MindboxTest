using System;
using Xunit;

namespace Shapes.Tests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(6, 6, 3)]
        [InlineData(6, 6, 6)]
        [InlineData(300, 400, 500)]
        [InlineData(600, 600, 300)]
        [InlineData(600, 600, 600)]
        public void TestConstructor_ValidSides_Success(double a, double b, double c)
        {
            Triangle actual = new Triangle(a, b, c);
            
            Assert.NotNull(actual);
            Assert.Equal(a, actual.A);
            Assert.Equal(b, actual.B);
            Assert.Equal(c, actual.C);
        }

        [Theory]
        [InlineData(-3, 4, 5)]
        [InlineData(3, -4, 5)]
        [InlineData(3, 4, -5)]
        [InlineData(-3, -4, 5)]
        [InlineData(-3, 4, -5)]
        [InlineData(-3, -4, -5)]
        public void TestConstructor_SidesLessThanZero_ThrowsArgumentOutOfRangeException(double a, double b, double c)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Triangle(a, b, c)
                );
        }

        [Theory]
        [InlineData(new double[] { 0.3, 0.4, 0.5 }, true)]
        [InlineData(new double[] { 3, 4, 5 }, true)]
        [InlineData(new double[] { 6, 6, 3 }, false)]
        [InlineData(new double[] { 6, 6, 6 }, false)]
        public void TestIsRight_ValidSides(double[] sides, bool expected)
        {
            const int aIndex = 0;
            const int bIndex = 1;
            const int cIndex = 2;

            Triangle triangle = new Triangle(sides[aIndex], sides[bIndex], sides[cIndex]);
            bool actual = triangle.IsRight();

            Assert.Equal(expected, actual);
        }



        [Theory]
        [InlineData(new double[] { 0.3, 0.4, 0.5 }, 0.06)]
        [InlineData(new double[] { 3, 4, 5 }, 6)]
        [InlineData(new double[] { 6, 6, 3 }, 8.7142)]
        [InlineData(new double[] { 6, 6, 6 }, 15.5885)]
        public void TestArea(double[] sides, double expected)
        {
            const int aIndex = 0;
            const int bIndex = 1;
            const int cIndex = 2;
            const int precision = 3;

            Triangle triangle = new Triangle(sides[aIndex], sides[bIndex], sides[cIndex]);
            double actual = triangle.Area;

            Assert.Equal(expected, actual, precision);
        }
    }
}
