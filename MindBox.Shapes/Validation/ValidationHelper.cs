namespace MindBox.Shapes.Validation;

public static class ValidationHelper
{
    public static void ThrowIfLessThanOrEqualTo<T>(T comparedValue, T comparingToValue, string exceptionMessage) 
        where T : IComparable<T> 
    {
        if (comparedValue.CompareTo(comparingToValue) <= 0)
        {
            throw new ArgumentException(exceptionMessage);
        }
    }
}