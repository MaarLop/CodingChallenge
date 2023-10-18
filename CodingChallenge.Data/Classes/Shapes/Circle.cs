using System;

namespace CodingChallenge.Data.Classes.Shapes
{
    internal class Circle : GeometricShape
    {
        private const decimal Pi = (decimal)Math.PI;

        public Circle(decimal radius) : base(radius)
        {
        }

        public override decimal CalculateArea() => Pi * (Side / 2) * (Side / 2);

        public override decimal CalculatePerimeter() => Pi * Side;
    }
}