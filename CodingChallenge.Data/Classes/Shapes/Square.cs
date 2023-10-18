namespace CodingChallenge.Data.Classes.Shapes
{
    internal class Square : GeometricShape
    {
        public Square(decimal side) : base(side)
        {
        }

        public override decimal CalculateArea() => Side * Side;

        public override decimal CalculatePerimeter() => Side * 4;
    }
}