namespace MindBox.Shapes.Extensions;

public static class DoubleExtensions
{
    public static bool EqualsWithTolerance(this double d1, double d2, double tolerance)
    {
        return Math.Abs(d1 - d2) < tolerance;
    }
}