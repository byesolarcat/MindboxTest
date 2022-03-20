using System;
using Xunit;

namespace Shapes.Tests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(0.1)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(1000)]
        [InlineData(2000)]
        [InlineData(3000)]
        public void TestConstructor_PositiveRadius_Success(double radius)
        {
            Circle actual = new Circle(radius);

            Assert.NotNull(actual);
            Assert.Equal(actual.Radius, radius);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-1000)]
        [InlineData(-2000)]
        [InlineData(-3000)]
        public void TestConstructor_LessThanZeroRadius_ThrowsArgumentOutOfRangeException(double radius)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Circle(radius)
            );
        }

        [Theory]
        [InlineData(0.1, 0.0314)]
        [InlineData(1, 3.14)]
        [InlineData(2, 12.57)]
        [InlineData(3, 28.27)]
        [InlineData(100, 31415.93)]
        public void TestArea(double radius, double expected)
        {
            const int precision = 2;

            Circle circle = new Circle(radius);
            double actual = circle.Area;

            Assert.Equal(expected, actual, precision);
        }
    }
}