using BowlingAlley.Core;

namespace BowlingAlley.Services
{
    public static class ScoreCalculator
    {
        private static readonly Random _random = new Random();

        public static int CalculateTurnScore()
        {
            return _random.Next(0, 11);
        }

        public static Player DetermineWinner(Player playerOne, Player playerTwo)
        {
            return playerOne.TotalScore > playerTwo.TotalScore ? playerOne :
                   playerTwo.TotalScore > playerOne.TotalScore ? playerTwo : null;
        }
    }
}
