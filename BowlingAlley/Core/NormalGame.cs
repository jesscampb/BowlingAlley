using BowlingAlley.Services;

namespace BowlingAlley.Core
{
    public class NormalGame : IGameMode
    {
        public void PlayGame(Player playerOne, Player playerTwo)
        {
            string gameMode = "Normal Game";
            Console.WriteLine(SimulationTextGenerator.GameModeMessage(playerOne, playerTwo, gameMode));

            int totalRounds = 3;

            for (int i = 1; i <= totalRounds; i++)
            {
                Console.WriteLine(SimulationTextGenerator.RoundMessage(i));
                PlayTurn(playerOne);
                PlayTurn(playerTwo);
            }

            Console.WriteLine(SimulationTextGenerator.FinalScoreMessage(playerOne, playerOne.TotalScore));
            Console.WriteLine(SimulationTextGenerator.FinalScoreMessage(playerTwo, playerTwo.TotalScore));

            Player winner = ScoreCalculator.DetermineWinner(playerOne, playerTwo);

            Console.WriteLine(winner == null ? 
                SimulationTextGenerator.TieMessage(playerOne.TotalScore) : 
                SimulationTextGenerator.WinnerMessage(winner, winner.TotalScore));

            Console.WriteLine(SimulationTextGenerator.GameFinishedMessage());
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
