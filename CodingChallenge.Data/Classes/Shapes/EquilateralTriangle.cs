using System;

namespace CodingChallenge.Data.Classes.Shapes
{
    internal class EquilateralTriangle : GeometricShape
    {
        public EquilateralTriangle(decimal side) : base(side)
        {
        }

        public override decimal CalculateArea() => ((decimal)Math.Sqrt(3) / 4) * Side * Side;

        public override decimal CalculatePerimeter() => Side * 3;
    }
}