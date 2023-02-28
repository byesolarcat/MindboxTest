namespace MindBox.Shapes.Models;

public interface IShape
{
    /// <summary>
    /// Возвращает площадь фигуры. 
    /// </summary>
    /// <returns>Значение площади фигуры.</returns>
    public double GetArea();
}