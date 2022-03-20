using System;

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
            A = a;
            B = b;
            C = c;
        }
    }
}