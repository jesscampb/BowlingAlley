using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
