using BowlingAlley.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAlley.Core
{
    public class NormalGame : IGameMode
    {
        public void PlayGame(Player playerOne, Player playerTwo)
        {
            int totalTurns = 3;

            for (int i = 1; i <= totalTurns; i++)
            {
                Console.WriteLine(SimulationTextGenerator.PlayerTurnMessage(playerOne));
                int playerOneScore = ScoreCalculator.CalculateTurnScore();
                playerOne.AddTurnScore(playerOneScore);
                Console.WriteLine(SimulationTextGenerator.PinsDownedMessage(playerOne, playerOneScore));
                Console.WriteLine(SimulationTextGenerator.PlayerTurnScoreMessage(playerOne, playerOneScore));

                Console.WriteLine(SimulationTextGenerator.PlayerTurnMessage(playerTwo));
                int playerTwoScore = ScoreCalculator.CalculateTurnScore();
                playerTwo.AddTurnScore(playerTwoScore);
                Console.WriteLine(SimulationTextGenerator.PinsDownedMessage(playerTwo, playerTwoScore));
                Console.WriteLine(SimulationTextGenerator.PlayerTurnScoreMessage(playerTwo, playerTwoScore));
            }

            Console.WriteLine(SimulationTextGenerator.FinalScoreMessage(playerOne, playerOne.TotalScore));
            Console.WriteLine(SimulationTextGenerator.FinalScoreMessage(playerTwo, playerTwo.TotalScore));

            Player winner = ScoreCalculator.DetermineWinner(playerOne, playerTwo);

            Console.WriteLine(winner == null ? 
                SimulationTextGenerator.TieMessage(playerOne.TotalScore) : 
                SimulationTextGenerator.WinnerMessage(winner, winner.TotalScore));
        }
    }
}
