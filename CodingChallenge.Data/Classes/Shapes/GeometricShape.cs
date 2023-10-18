using CodingChallenge.Data.Recursos;
using CodingChallenge.Guards;

namespace CodingChallenge.Data.Classes.Shapes
{
    public abstract class GeometricShape
    {
        protected decimal Side { get; }

        protected GeometricShape(decimal side)
        {
            Guard.Against.NegativeOrZero(side, ResX.Side_of_a_shape_must_be_positive);
            Side = side;
        }

        public abstract decimal CalculateArea();

        public abstract decimal CalculatePerimeter();
    }
}