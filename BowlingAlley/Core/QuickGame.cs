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
            PlayTurn(playerOne);
            PlayTurn(playerTwo);

            Console.WriteLine(SimulationTextGenerator.FinalScoreMessage(playerOne, playerOne.TotalScore));
            Console.WriteLine(SimulationTextGenerator.FinalScoreMessage(playerTwo, playerTwo.TotalScore));

            Player winner = ScoreCalculator.DetermineWinner(playerOne, playerTwo);

            Console.WriteLine(winner == null ?
                SimulationTextGenerator.TieMessage(playerOne.TotalScore) :
                SimulationTextGenerator.WinnerMessage(winner, winner.TotalScore));
        }

        private void PlayTurn(Player player)
        {
            Console.WriteLine(SimulationTextGenerator.PlayerTurnMessage(player));

            int turnScore = ScoreCalculator.CalculateTurnScore();
            player.AddTurnScore(turnScore);

            Console.WriteLine(SimulationTextGenerator.PinsDownedMessage(player, turnScore));
            Console.WriteLine(SimulationTextGenerator.PlayerTurnScoreMessage(player, turnScore));
        }
    }
}
