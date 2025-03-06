using BowlingAlley.Core;

namespace BowlingAlley.Data
{
    public interface IPlayerRepository
    {
        void AddPlayer(Player player);
        Player? GetPlayer(string name);
        List<Player> GetAllPlayers();
    }
}
