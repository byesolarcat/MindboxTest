using System;

namespace Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area => Math.PI * Math.Pow(Radius, 2);

        public Circle(double radius)
        {
            if (radius <= 0) 
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be bigger than zero.");
            }

            Radius = radius;
        }
    }
}