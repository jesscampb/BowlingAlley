using BowlingAlley.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAlley.Factories
{
    public static class GameFactory
    {
        public static Game CreateGame(Player playerOne, Player playerTwo, int choice)
        {
            IGameMode gameMode = choice switch
            {
                1 => new QuickGame(),
                2 => new NormalGame(),
                _ => throw new ArgumentException("Invalid game mode.")
            };
            
            return new Game(playerOne, playerTwo, gameMode);
        }
    }
}
