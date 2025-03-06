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

        public void StartGame()
        {
            _gameMode.PlayGame(_playerOne, _playerTwo);
        }
    }
}
