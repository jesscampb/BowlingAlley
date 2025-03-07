using BowlingAlley.Core;

namespace BowlingAlley.Services
{
    public static class SimulationTextGenerator
    {
        public static string GameModeMessage(Player playerOne, Player playerTwo, string gameMode)
        {
            return $"\nStarting a game in {gameMode} between players {playerOne.Name} and {playerTwo.Name}...";
        }

        public static string GameStartMessage()
        {
            return "\nThe game is on!";
        }

        public static string RoundStartMessage(int round)
        {
            return $"\nRound {round} has started. Grab your balls!";
        }

        public static string RoundEndMessage(int round)
        {
            return $"\nRound {round} finished!";
        }

        public static string PlayerTurnMessage(Player player)
        {
            return $"\n{player.Name}, it's your turn to play!";
        }

        public static string PlayerTurnActionMessage(Player player)
        {
            return $"\n{player.Name} takes a deep breath... it's time to roll!";
        }

        public static string PinsDownedMessage(Player player, int pins)
        {
            return pins switch
            {
                0 => $"\nOops! {player.Name} throws a gutter ball... No pins downed!",
                10 => $"\nSTRIKE!! {player.Name} knocks down all the pins!",
                _ => $"\n{player.Name} knocks down {pins} pins!"
            };
        }

        public static string PlayerTurnScoreMessage(Player player, int turnScore)
        {
            return $"{player.Name} scored {turnScore} points this turn.";
        }

        public static string CalculateFinalScoreMessage()
        {
            return "\nCalculating final scores...";
        }

        public static string FinalScoreMessage(Player player, int finalScore)
        {
            return $"{player.Name} scored {finalScore} points in total.";
        }

        public static string CompareScoresMessage()
        {
            return "\nComparing player scores to determine a winner...";
        }

        public static string WinnerMessage(Player winner, int finalScore)
        {
            return $"\nCongratulations {winner.Name}! You won the game with a score of {finalScore} points!";
        }

        public static string TieMessage(int finalScore)
        {
            return $"\n It's a tie! Both players scored {finalScore} points.";
        }

        public static string GameFinishedMessage()
        {
            return "\nGame finished! Thank you for playing.";
        }
    }
}
