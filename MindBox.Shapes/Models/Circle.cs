using MindBox.Shapes.Validation;

namespace MindBox.Shapes.Models;

public class Circle : IShape
{
    private readonly double _radius;

    /// <summary>
    /// Создаёт круг с радиусом <paramref name="radius"/>.
    /// </summary>
    /// <param name="radius">Радиус круга. Не может быть меньше или равен нулю.</param>
    public Circle(double radius)
    {
        ValidationHelper.ThrowIfLessThanOrEqualTo(radius, 0, "Passed radius is less or equal to zero.");
        
        _radius = radius;
    }

    /// <summary>
    /// Возвращает площадь круга.
    /// </summary>
    /// <returns>Значение площади круга.</returns>
    public double GetArea()
    {
        return Math.PI * Math.Pow(_radius, 2);
    } 
}