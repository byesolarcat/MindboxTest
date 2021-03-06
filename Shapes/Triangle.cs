using System;
using System.Collections.Generic;
using System.Linq;

namespace Shapes
{
    public class Triangle : Shape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public override double Area => Math.Sqrt(
            HalfPerimeter *
            (HalfPerimeter - A) *
            (HalfPerimeter - B) *
            (HalfPerimeter - C));
        public double Perimeter => A + B + C;
        
        private double HalfPerimeter => Perimeter / 2;

        public Triangle(double a, double b, double c)
        {
            const string lessThanZeroMessageFormat = "Side length must be bigger than zero.";
            if (a <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a), lessThanZeroMessageFormat);
            }
            if (b <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(b), lessThanZeroMessageFormat);
            }
            if (c <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(c), lessThanZeroMessageFormat);
            }

            if (!IsValid(a, b, c))
            {
                throw new InvalidOperationException("Cannot create triangle with these sides.");
            }

            A = a;
            B = b;
            C = c;
        }

        public bool IsRight()
        {
            const double comparisonTolerance = 0.0001;
            double[] sides = new double[] {A, B, C};
            double[] sidesAscending = sides.OrderBy(x => x).ToArray();
            
            return CompareWithTolerance(
                Math.Pow(sidesAscending[0], 2) + Math.Pow(sidesAscending[1], 2), 
                Math.Pow(sidesAscending[2], 2), 
                comparisonTolerance);
        }

        private static bool IsValid(double a, double b, double c)
        {
            return (a + b > c)
                   && (a + c > b)
                   && (b + c > a);
        }

        private static bool CompareWithTolerance(double a, double b, double tolerance)
        {
            return Math.Abs(a - b) < tolerance;
        }
    }
}