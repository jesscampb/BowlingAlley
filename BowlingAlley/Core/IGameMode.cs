using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAlley.Core
{
    public interface IGameMode
    {
        void PlayGame(Player playerOne, Player playerTwo);
    }
}
