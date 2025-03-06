using BowlingAlley.Services;

namespace BowlingAlley.Core
{
    public class Game
    {
        private readonly Player _playerOne;
        private readonly Player _playerTwo;
        private readonly IGameMode _gameMode;

        public Game(Player playerOne, Player playerTwo, IGameMode gameMode)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _gameMode = gameMode;
        }

        // Starts the game between two players based on the selected game mode
        public void StartGame()
        {
            SingletonLogger.Instance.Log("Game started.");
            _gameMode.PlayGame(_playerOne, _playerTwo);
        }
    }
}
