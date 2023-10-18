using CodingChallenge.Data.Helpers;
using CodingChallenge.Data.Resource;
using CodingChallenge.Guards;

namespace CodingChallenge.Data.Classes.Shapes
{
    internal class Rectangle : GeometricShape
    {
        public decimal Width { get; set; }

        public Rectangle(decimal side, decimal width) : base(side)
        {
            Guard.Against.NegativeOrZero(width, ResX.Side_of_a_shape_must_be_positive);
            Width = width;
        }

        public override decimal CalculateArea() => Width * Side;

        public override decimal CalculatePerimeter() => 2 * (Width + Side);
    }
}