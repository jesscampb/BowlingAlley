using BowlingAlley.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAlley.Services
{
    public static class SimulationTextGenerator
    {
        public static string PlayerTurnMessage(Player player)
        {
            return $"{player.Name}, it's your turn to play!";
        }

        public static string PlayerTurnPinsMessage(Player player, int pins)
        {
            return pins switch
            {
                0 => $"Oops! {player.Name} throws a gutter ball... No pins downed!",
                10 => $"STRIKE!! {player.Name} knocks down all the pins!",
                _ => $"{player.Name} knocks down {pins} pins!"
            };
        }

        public static string PlayerTurnScoreMessage(Player player, int turnScore)
        {
            return $"{player.Name} scored {turnScore} points this turn.";
        }

        public static string FinalScoreMessage(Player player, int finalScore)
        {
            return $"{player.Name} scored {finalScore} points in total.";
        }

        public static string WinnerMessage(Player winner, int finalScore)
        {
            return $"Congratulations {winner.Name}! You won the game with a final score of {finalScore}!";
        }

        public static string TieMessage(int finalScore)
        {
            return $"It's a tie! Both players scored {finalScore} points.";
        }
    }
}
