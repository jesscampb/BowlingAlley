using BowlingAlley.Services;

namespace BowlingAlley.Core
{
    // This class represents the quick game mode choice
    public class QuickGame : IGameMode
    {
        private readonly SingletonLogger _logger = SingletonLogger.Instance;

        public void PlayGame(Player playerOne, Player playerTwo)
        {
            string gameMode = "Quick Mode";
            _logger.Log($"Game started in {gameMode} between {playerOne.Name} and {playerTwo.Name}.");
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
            _logger.Log("Game ended.");
            _logger.Log($"{playerOne.Name}: {playerOne.TotalScore} points.");
            _logger.Log($"{playerTwo.Name}: {playerTwo.TotalScore} points.");
        }

        private void PlayTurn(Player player)
        {
            Console.WriteLine(SimulationTextGenerator.PlayerTurnMessage(player));
            ThrowBall(player);

            Console.WriteLine(SimulationTextGenerator.PlayerTurnActionMessage(player));

            int turnScore = ScoreCalculator.CalculateTurnScore();
            player.AddTurnScore(turnScore);
            _logger.Log($"{player.Name} played turn and scored {turnScore} points.");

            Console.WriteLine(SimulationTextGenerator.PinsDownedMessage(player, turnScore));
            Console.WriteLine(SimulationTextGenerator.PlayerTurnScoreMessage(player, turnScore));
        }

        private void ThrowBall(Player player)
        {
            Console.WriteLine("Press any key to throw the ball.");
            Console.ReadKey();
            _logger.Log($"{player.Name} threw the ball.");
        }
    }
}
