using BowlingAlley.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAlley.Data
{
    public interface IPlayerRepo
    {
        void AddPlayer(Player player);
        Player? GetPlayer(string name);
        List<Player> GetAllPlayers();
    }
}
