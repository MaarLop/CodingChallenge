namespace CodingChallenge.Guards
{
    public class Guard : IGuardClause
    {
        public static IGuardClause Against { get; } = (IGuardClause)new Guard();

        private Guard()
        {
        }
    }
}