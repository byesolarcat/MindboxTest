using MindBox.Shapes.Extensions;
using MindBox.Shapes.Validation;

namespace MindBox.Shapes.Models;

public class Triangle : IShape
{
    // Не известно надо ли их делать приватными полями или свойствами, оставил полями.
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    // Есть ещё варианты создать треугольник (через сторону и два угла и т.д.)
    // но надеюсь в целях тестового задания достаточно этого.
    /// <summary>
    /// Создаёт треугольник по заданным длинам сторон <paramref name="a"/>, <paramref name="b"/> и <paramref name="c"/>.
    /// </summary>
    /// <param name="a">Длина стороны A.</param>
    /// <param name="b">Длина стороны B.</param>
    /// <param name="c">Длина стороны C.</param>
    /// <remarks>Стороны не должны быть меньше или равны нулю.</remarks>
    public Triangle(double a, double b, double c)
    {
        ValidationHelper.ThrowIfLessThanOrEqualTo(a, 0, $"Side A is less than or equal to zero.");
        ValidationHelper.ThrowIfLessThanOrEqualTo(b, 0, $"Side B is less than or equal to zero.");
        ValidationHelper.ThrowIfLessThanOrEqualTo(c, 0, $"Side C is less than or equal to zero.");

        if (!CanBuildWithSides(a, b, c))
        {
            throw new InvalidOperationException("Can't create triangle with sides A={a}, B={b}, C={c}.");
        }
        
        _a = a;
        _b = b;
        _c = c;
    }

    /// <summary>
    /// Возвращает площадь треугольника.
    /// </summary>
    /// <returns>Значение площади треугольника.</returns>
    public double GetArea()
    {
        // Можно было бы вынести периметр в свойство
        // но по заданию такого требования нет, так что оставляю тут.
        var halfPerimeter = (_a + _b + _c) / 2;

        // Формула Херона
        // s - половина периметра
        // Area = Sqrt(s(s-a)(s-b)(s-c))
        return Math.Sqrt(halfPerimeter * (halfPerimeter - _a) * (halfPerimeter - _b) * (halfPerimeter - _c));
    }
    
    /// <summary>
    /// Проверяет является треугольник прямоугольным.
    /// </summary>
    /// <returns>True, если треугольник - прямоугольный, иначе false.</returns>
    public bool IsRight()
    {
        const double comparisonTolerance = 0.00001;

        double aSquared = Math.Pow(_a, 2);
        double bSquared = Math.Pow(_b, 2);
        double cSquared = Math.Pow(_c, 2);
        
        // Проверяем можно ли построить прямоугольный треугольник при помощи теоремы Пифагора:
        // A^2 + B^2 == C^2
        // Т.е. треугольник прямоугольный если сумма квадратов двух его сторон равна квадрату третьей стороны.
        return aSquared.EqualsWithTolerance(bSquared + cSquared, comparisonTolerance) || 
               bSquared.EqualsWithTolerance(aSquared + cSquared, comparisonTolerance) || 
               cSquared.EqualsWithTolerance(aSquared + bSquared, comparisonTolerance);
    }

    /// <summary>
    /// Проверяет можно ли построить треугольник с заданными сторонами.
    /// </summary>
    /// <param name="a">Длина стороны A.</param>
    /// <param name="b">Длина стороны B.</param>
    /// <param name="c">Длина стороны C.</param>
    /// <returns>True, если треугольник можно построить, иначе false.</returns>
    /// <remarks>Сумма длин двух любых сторон должна быть больше длины третьей стороны.</remarks>
    private static bool CanBuildWithSides(double a, double b, double c)
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }
}