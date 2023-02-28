using MindBox.Shapes.Models;
using NUnit.Framework;

namespace MindBox.Shapes.Tests.Models;

[TestFixture(TestOf = typeof(Triangle))]
public class TriangleTests
{
    [Test]
    [Category("Triangle Constructor")]
    [TestCase(2, 3, 4)]
    [TestCase(2, 4, 3)]
    [TestCase(3, 2, 4)]
    [TestCase(3, 4, 2)]
    [TestCase(4, 2, 3)]
    [TestCase(4, 3, 2)]
    [TestCase(3, 4, 5)]
    [TestCase(200000, 300000, 400000)]
    [TestCase(200000, 400000, 300000)]
    [TestCase(300000, 200000, 400000)]
    [TestCase(300000, 400000, 200000)]
    [TestCase(400000, 200000, 300000)]
    [TestCase(400000, 300000, 200000)]
    public void Triangle_CreateWithPositiveSides_Success(double a, double b, double c)
    {
        Assert.That(() => new Triangle(a, b, c), Throws.Nothing);
    }
    
    [Test]
    [Category("Triangle Constructor")]
    [TestCase(-2, 3, 4)]
    [TestCase(2, -3, 4)]
    [TestCase(2, 3, -4)]
    [TestCase(-2, -3, 4)]
    [TestCase(2, -3, -4)]
    [TestCase(-2, 3, -4)]
    [TestCase(-2, -3, -4)]
    public void Triangle_CreateWithNegativeSides_Failure(double a, double b, double c)
    {
        Assert.That(() => new Triangle(a, b, c), Throws.ArgumentException);
    }
    
    [Test]
    [Category("Triangle Area")]
    [TestCase(2, 3, 4, 2.9047375)]
    [TestCase(2, 4, 3, 2.9047375)]
    [TestCase(3, 2, 4, 2.9047375)]
    [TestCase(3, 4, 2, 2.9047375)]
    [TestCase(4, 2, 3, 2.9047375)]
    [TestCase(4, 3, 2, 2.9047375)]
    [TestCase(20, 30, 40, 290.47375096)]
    [TestCase(200000, 300000, 400000, 29047375096.555626)]
    [TestCase(3, 4, 5, 6)]
    [TestCase(30, 40, 50, 600)]
    [TestCase(300000, 400000, 500000, 60000000000)]
    public void Triangle_GetArea_Success(double a, double b, double c, double expectedArea)
    {
        const double comparisonTolerance = 0.00001;
        Triangle triangle = new Triangle(a, b, c);

        double actualArea = triangle.GetArea();
        
        Assert.That(actualArea, Is.EqualTo(expectedArea).Within(comparisonTolerance));
    }
    
    [Test]
    [Category("Triangle Is Right")]
    [TestCase(2, 3, 4, false)]
    [TestCase(2, 4, 3, false)]
    [TestCase(3, 2, 4, false)]
    [TestCase(3, 4, 2, false)]
    [TestCase(4, 2, 3, false)]
    [TestCase(4, 3, 2, false)]
    [TestCase(3, 4, 5, true)]
    [TestCase(3, 5, 4, true)]
    [TestCase(4, 3, 5, true)]
    [TestCase(4, 5, 3, true)]
    [TestCase(5, 3, 4, true)]
    [TestCase(5, 4, 3, true)]
    public void Triangle_IsRight_Success(double a, double b, double c, bool expectedIsRight)
    {
        Triangle triangle = new Triangle(a, b, c);

        bool actualIsRight = triangle.IsRight();
        
        Assert.That(actualIsRight, Is.EqualTo(expectedIsRight));
    }
}