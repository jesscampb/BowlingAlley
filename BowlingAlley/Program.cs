using BowlingAlley.Data;
using BowlingAlley.Services;

namespace BowlingAlley
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPlayerRepository playerRepo = new PlayerRepository();
            PlayerInteraction playerInteraction = new PlayerInteraction(playerRepo);

            playerInteraction.WelcomeMessage();
        }
    }
}
