using BowlingAlley.Services;

namespace BowlingAlley.Core
{
    public class QuickGame : IGameMode
    {
        public void PlayGame(Player playerOne, Player playerTwo)
        {
            string gameMode = "Quick Mode";
            SingletonLogger.Instance.Log($"A game started in {gameMode}.");
            Console.WriteLine(SimulationTextGenerator.GameModeMessage(playerOne, playerTwo, gameMode));

            PlayTurn(playerOne);
            PlayTurn(playerTwo);

            Console.WriteLine(SimulationTextGenerator.CalculateFinalScoreMessage());
            Console.WriteLine(SimulationTextGenerator.FinalScoreMessage(playerOne, playerOne.TotalScore));
            Console.WriteLine(SimulationTextGenerator.FinalScoreMessage(playerTwo, playerTwo.TotalScore));

            Console.WriteLine(SimulationTextGenerator.CompareScoresMessage());
            Player winner = ScoreCalculator.DetermineWinner(playerOne, playerTwo);

            Console.WriteLine(winner == null ?
                SimulationTextGenerator.TieMessage(playerOne.TotalScore) :
                SimulationTextGenerator.WinnerMessage(winner, winner.TotalScore));

            Console.WriteLine(SimulationTextGenerator.GameFinishedMessage());
            SingletonLogger.Instance.Log("Game ended.");
        }

        private void PlayTurn(Player player)
        {
            Console.WriteLine(SimulationTextGenerator.PlayerTurnMessage(player));
            Console.WriteLine(SimulationTextGenerator.PlayerTurnActionMessage(player));

            int turnScore = ScoreCalculator.CalculateTurnScore();
            player.AddTurnScore(turnScore);
            SingletonLogger.Instance.Log($"{player.Name} played turn and scored {turnScore} points.");

            Console.WriteLine(SimulationTextGenerator.PinsDownedMessage(player, turnScore));
            Console.WriteLine(SimulationTextGenerator.PlayerTurnScoreMessage(player, turnScore));
        }
    }
}
