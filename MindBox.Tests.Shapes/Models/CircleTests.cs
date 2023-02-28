using MindBox.Shapes.Models;
using NUnit.Framework;

namespace MindBox.Shapes.Tests.Models;

[TestFixture(TestOf = typeof(Circle))]
public class Tests
{
    [Test]
    [Category("Circle Constructor")]
    [TestCase(0.01)]
    [TestCase(1)]
    [TestCase(1.01)]
    [TestCase(1.99)]
    [TestCase(2)]
    [TestCase(5)]
    [TestCase(10)]
    [TestCase(100)]
    [TestCase(100000)]
    public void Circle_CreateWithPositiveRadius_Success(double radius)
    {
        Assert.That(() => new Circle(radius), Throws.Nothing);
    }

    [Test]
    [Category("Circle Constructor")]
    [TestCase(0)]
    [TestCase(-0.01)]
    [TestCase(-1)]
    [TestCase(-1.01)]
    [TestCase(-1.99)]
    [TestCase(-2)]
    [TestCase(-5)]
    [TestCase(-10)]
    [TestCase(-100)]
    [TestCase(-100000)]
    public void Circle_CreateWithIncorrectRadius_Failure(double radius)
    {
        Assert.That(() => new Circle(radius), Throws.ArgumentException);
    }

    [Test]
    [Category("Circle Area")]
    [TestCase(0.001, 0.0000031416)]
    [TestCase(0.99, 3.07907)]
    [TestCase(1, Math.PI)]
    [TestCase(2, 12.56637)]
    [TestCase(10, 314.15927)]
    [TestCase(100000, 31415926535.897928)]
    public void Circle_GetArea_Success(double radius, double expectedArea)
    {
        const double comparisonTolerance = 0.00001;
        Circle circle = new Circle(radius);

        double actualArea = circle.GetArea();
        
        Assert.That(actualArea, Is.EqualTo(expectedArea).Within(comparisonTolerance));
    }
}