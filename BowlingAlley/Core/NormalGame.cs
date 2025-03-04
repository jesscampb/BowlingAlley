using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAlley.Core
{
    public class NormalGame: IGameMode
    {
        public void PlayGame(Player playerOne, Player playerTwo)
        {
            Console.WriteLine($"Starting a bowling game in Normal Mode between players {playerOne.Name} and {playerTwo.Name}...");
        }
    }
}
