using System;
using CodingChallenge.Data.Classes.Shapes;
using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Recursos;

namespace CodingChallenge.Data.Factories
{
    public static class ShapeFactory
    {
        public static GeometricShape CreateShape(Shape type, decimal size, decimal width = 0, decimal minor = 0, decimal major = 0) =>
            type switch
            {
                Shape.Square => new Square(size),
                Shape.Circle => new Circle(size),
                Shape.EquilateralTriangle => new EquilateralTriangle(size),
                Shape.Rectangle => new Rectangle(size, width),
                Shape.Trapeze => new Trapeze(major, minor, size),
                _ => throw new ArgumentException(ResX.InvalidEnumValueForShape, nameof(type))
            };
    }
}