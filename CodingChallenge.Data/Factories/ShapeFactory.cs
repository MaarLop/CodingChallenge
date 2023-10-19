using System;
using CodingChallenge.Data.Classes.Shapes;
using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Resource;

namespace CodingChallenge.Data.Factories
{
    public static class ShapeFactory
    {
        public static GeometricShape CreateShape(Shape type, decimal size, decimal width = 0, decimal major = 0)
        {
            switch (type)
            {
                case Shape.Square:
                    return new Square(size);

                case Shape.Circle:
                    return new Circle(size);

                case Shape.EquilateralTriangle:
                    return new EquilateralTriangle(size);

                case Shape.Rectangle:
                    return new Rectangle(size, width);

                case Shape.Trapeze:
                    return new Trapeze(major, width, size);

                default:
                    throw new ArgumentException(ResX.InvalidEnumValueForShape, nameof(type));
            }
        }
    }
}