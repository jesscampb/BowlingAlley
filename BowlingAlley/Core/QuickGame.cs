using BowlingAlley.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAlley.Core
{
    public class QuickGame : IGameMode
    {
        public void PlayGame(Player playerOne, Player playerTwo)
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

            Console.WriteLine(SimulationTextGenerator.FinalScoreMessage(playerOne, playerOneScore));
            Console.WriteLine(SimulationTextGenerator.FinalScoreMessage(playerTwo, playerTwoScore));

            Player winner = ScoreCalculator.DetermineWinner(playerOne, playerTwo);

            if (winner == null)
            {
                Console.WriteLine(SimulationTextGenerator.TieMessage(playerOne.TotalScore));
            }
            else
            {
                Console.WriteLine(SimulationTextGenerator.WinnerMessage(winner, winner.TotalScore));
            }
        }
    }
}
