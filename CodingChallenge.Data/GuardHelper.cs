using System;
using CodingChallenge.Guards;

namespace CodingChallenge.Data
{
    public static class GuardHelper
    {
        public static T NegativeOrZero<T>(this IGuardClause guardClause, T value, string message) where T : IComparable
        {
            return value.CompareTo((object)default(T)) > 0 ? value : throw new ArgumentException(message);
        }
    }
}