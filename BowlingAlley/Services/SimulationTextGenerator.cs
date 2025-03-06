﻿using BowlingAlley.Core;

namespace BowlingAlley.Services
{
    public static class SimulationTextGenerator
    {
        public static string GameModeMessage(Player playerOne, Player playerTwo, string gameMode)
        {
            return $"A new game in {gameMode} is starting between {playerOne.Name} and {playerTwo.Name}...";
        }

        public static string RoundStartMessage(int round)
        {
            return $"Round {round} starts now. Grab your balls!";
        }

        public static string RoundEndMessage(int round)
        {
            return $"Round {round} finished. Time to calculate scores!";
        }

        public static string PlayerTurnMessage(Player player)
        {
            return $"{player.Name}, it's your turn to play!";
        }

        public static string PlayerTurnActionMessage(Player player)
        {
            return $"{player.Name} takes a deep breath... it's time to roll!";
        }

        public static string PinsDownedMessage(Player player, int pins)
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

        public static string CalculateFinalScoreMessage()
        {
            return "Calculating final scores...";
        }

        public static string FinalScoreMessage(Player player, int finalScore)
        {
            return $"{player.Name} scored {finalScore} points in total.";
        }

        public static string CompareScoresMessage()
        {
            return $"Comparing player scores...";
        }

        public static string WinnerMessage(Player winner, int finalScore)
        {
            return $"Congratulations {winner.Name}! You won the game with {finalScore} points!";
        }

        public static string TieMessage(int finalScore)
        {
            return $"It's a tie! Both players scored {finalScore} points.";
        }

        public static string GameFinishedMessage()
        {
            return "Game finished! Thank you for playing.";
        }
    }
}
