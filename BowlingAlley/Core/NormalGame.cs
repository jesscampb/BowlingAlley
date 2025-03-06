using BowlingAlley.Services;

namespace BowlingAlley.Core
{
    public class NormalGame : IGameMode
    {
        public void PlayGame(Player playerOne, Player playerTwo)
        {
            string gameMode = "Normal Mode";
            SingletonLogger.Instance.Log($"A game started in {gameMode}.");
            Console.WriteLine(SimulationTextGenerator.GameModeMessage(playerOne, playerTwo, gameMode));

            int totalRounds = 3;

            for (int i = 1; i <= totalRounds; i++)
            {
                SingletonLogger.Instance.Log($"Round {i} start.");
                Console.WriteLine(SimulationTextGenerator.RoundStartMessage(i));

                PlayTurn(playerOne);
                PlayTurn(playerTwo);

                SingletonLogger.Instance.Log($"Round {i} end.");
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
        }

        private void PlayTurn(Player player)
        {
            Console.WriteLine(SimulationTextGenerator.PlayerTurnMessage(player));
            Console.WriteLine(SimulationTextGenerator.PlayerTurnActionMessage(player));

            int turnScore = ScoreCalculator.CalculateTurnScore();
            player.AddTurnScore(turnScore);
            SingletonLogger.Instance.Log($"Player {player.Name} finished turn with a score of {turnScore} points.");

            Console.WriteLine(SimulationTextGenerator.PinsDownedMessage(player, turnScore));
            Console.WriteLine(SimulationTextGenerator.PlayerTurnScoreMessage(player, turnScore));
        }
    }
}
