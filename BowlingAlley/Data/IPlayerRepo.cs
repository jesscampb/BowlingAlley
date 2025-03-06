using BowlingAlley.Core;

namespace BowlingAlley.Data
{
    public interface IPlayerRepo
    {
        void AddPlayer(Player player);
        Player? GetPlayer(string name);
        List<Player> GetAllPlayers();
    }
}
