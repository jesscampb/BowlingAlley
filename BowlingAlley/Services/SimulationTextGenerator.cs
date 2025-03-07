using BowlingAlley.Core;

namespace BowlingAlley.Services
{
    public static class SimulationTextGenerator
    {
        public static string GameModeMessage(Player playerOne, Player playerTwo, string gameMode)
        {
            return $"{Environment.NewLine}Starting a game in {gameMode} between players {playerOne.Name} and {playerTwo.Name}...";
        }

        public static string GameStartMessage()
        {
            return $"{Environment.NewLine}The game is on!";
        }

        public static string RoundStartMessage(int round)
        {
            return $"{Environment.NewLine}Round {round} has started. Grab your balls!";
        }

        public static string RoundEndMessage(int round)
        {
            return $"{Environment.NewLine}Round {round} finished!";
        }

        public static string PlayerTurnMessage(Player player)
        {
            return $"{Environment.NewLine}{player.Name}, it's your turn to play!";
        }

        public static string PlayerTurnActionMessage(Player player)
        {
            return $"{Environment.NewLine}{player.Name} takes a deep breath... it's time to roll!";
        }

        public static string PinsDownedMessage(Player player, int pins)
        {
            return pins switch
            {
                0 => $"{Environment.NewLine}Oops! {player.Name} throws a gutter ball... No pins downed!",
                10 => $"{Environment.NewLine}STRIKE!! {player.Name} knocks down all the pins!",
                _ => $"{Environment.NewLine}{player.Name} knocks down {pins} pins!"
            };
        }

        public static string PlayerTurnScoreMessage(Player player, int turnScore)
        {
            return $"{player.Name} scored {turnScore} points this turn.";
        }

        public static string CalculateFinalScoreMessage()
        {
            return $"{Environment.NewLine}Calculating final scores...";
        }

        public static string FinalScoreMessage(Player player, int finalScore)
        {
            return $"{player.Name} scored {finalScore} points in total.";
        }

        public static string CompareScoresMessage()
        {
            return $"{Environment.NewLine}Comparing player scores to determine a winner...";
        }

        public static string WinnerMessage(Player winner, int finalScore)
        {
            return $"{Environment.NewLine}Congratulations {winner.Name}! You won the game with a score of {finalScore} points!";
        }

        public static string TieMessage(int finalScore)
        {
            return $"{Environment.NewLine} It's a tie! Both players scored {finalScore} points.";
        }

        public static string GameFinishedMessage()
        {
            return $"{Environment.NewLine}Game finished! Thank you for playing.";
        }
    }
}
