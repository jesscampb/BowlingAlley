using BowlingAlley.Core;

namespace BowlingAlley.Factories
{
    // Factory Pattern class that creates a game based on the player's choice
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
