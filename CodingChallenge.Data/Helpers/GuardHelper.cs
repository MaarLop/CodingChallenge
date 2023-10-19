using System;
using CodingChallenge.Guards;

namespace CodingChallenge.Data.Helpers
{
    public static class GuardHelper
    {
        public static T NegativeOrZero<T>(this IGuardClause _, T value, string message) where T : IComparable
        {
            return value.CompareTo(default(T)) > 0 ? value : throw new ArgumentException(message);
        }

        public static T IsNull<T>(this IGuardClause _, T value, string message)
        {
            return value == null ? throw new ArgumentException(message) : value;
        }

        public static decimal GreaterOrEqualsThan(this IGuardClause _, decimal minorValue, decimal majorValue, string message)
        {
            return minorValue >= majorValue ? throw new ArgumentException(message) : minorValue;
        }
    }
}