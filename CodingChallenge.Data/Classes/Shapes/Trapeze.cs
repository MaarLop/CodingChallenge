using System;
using CodingChallenge.Data.Recursos;
using CodingChallenge.Guards;

namespace CodingChallenge.Data.Classes.Shapes
{
    internal class Trapeze : GeometricShape
    {
        public decimal MajorBase { get; }
        public decimal MinorBase { get; }

        public Trapeze(decimal majorBase, decimal minorBase, decimal side) : base(side)
        {
            Guard.Against.NegativeOrZero(minorBase, ResX.Side_of_a_shape_must_be_positive);
            Guard.Against.NegativeOrZero(majorBase, ResX.Side_of_a_shape_must_be_positive);
            MajorBase = majorBase;
            MinorBase = minorBase;
        }

        public override decimal CalculateArea() => ((MajorBase + MinorBase) / 2) * Side;

        public override decimal CalculatePerimeter() => MajorBase + MinorBase +
                                                        2 * (Side / (decimal)Math.Sin(
                                                            Math.Atan((double)((MajorBase - MinorBase) / (2 * Side)))));
    }
}