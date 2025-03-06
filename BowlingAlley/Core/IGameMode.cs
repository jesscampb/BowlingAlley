namespace BowlingAlley.Core
{
    // Interface for game modes
    public interface IGameMode
    {
        void PlayGame(Player playerOne, Player playerTwo);
    }
}
