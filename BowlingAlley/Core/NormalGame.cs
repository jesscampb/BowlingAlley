using BowlingAlley.Services;

namespace BowlingAlley.Core
{
    public class NormalGame : IGameMode
    {
        private readonly SingletonLogger _logger = SingletonLogger.Instance;
        public void PlayGame(Player playerOne, Player playerTwo)
        {
            string gameMode = "Normal Mode";
            _logger.Log($"Game started in {gameMode} between {playerOne.Name} and {playerTwo.Name}.");
            Console.WriteLine(SimulationTextGenerator.GameModeMessage(playerOne, playerTwo, gameMode));

            int totalRounds = 3;

            for (int i = 1; i <= totalRounds; i++)
            {
                _logger.Log($"Round {i} start.");
                Console.WriteLine(SimulationTextGenerator.RoundStartMessage(i));

                PlayTurn(playerOne);
                PlayTurn(playerTwo);

                _logger.Log($"Round {i} end.");
                Console.WriteLine(SimulationTextGenerator.RoundEndMessage(i));

            }

            Console.WriteLine(SimulationTextGenerator.CalculateFinalScoreMessage());
            Console.WriteLine(SimulationTextGenerator.FinalScoreMessage(playerOne, playerOne.TotalScore));
            Console.WriteLine(SimulationTextGenerator.FinalScoreMessage(playerTwo, playerTwo.TotalScore));

            Console.WriteLine(SimulationTextGenerator.CompareScoresMessage());
            Player winner = ScoreCalculator.DetermineWinner(playerOne, playerTwo);

            Console.WriteLine(winner == null ? 
                SimulationTextGenerator.TieMessage(playerOne.TotalScore) : 
                SimulationTextGenerator.WinnerMessage(winner, winner.TotalScore));

            Console.WriteLine(SimulationTextGenerator.GameFinishedMessage());
            _logger.Log("Game ended. Final scores:");
            _logger.Log($"{playerOne.Name}: {playerOne.TotalScore} points.");
            _logger.Log($"{playerTwo.Name}: {playerTwo.TotalScore} points.");
        }

        private void PlayTurn(Player player)
        {
            Console.WriteLine(SimulationTextGenerator.PlayerTurnMessage(player));
            Console.WriteLine(SimulationTextGenerator.PlayerTurnActionMessage(player));

            int turnScore = ScoreCalculator.CalculateTurnScore();
            player.AddTurnScore(turnScore);
            _logger.Log($"Player {player.Name} finished turn with a score of {turnScore} points.");

            Console.WriteLine(SimulationTextGenerator.PinsDownedMessage(player, turnScore));
            Console.WriteLine(SimulationTextGenerator.PlayerTurnScoreMessage(player, turnScore));
        }
    }
}
