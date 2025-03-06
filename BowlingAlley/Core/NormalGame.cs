using BowlingAlley.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAlley.Core
{
    public class NormalGame : IGameMode
    {
        public void PlayGame(Player playerOne, Player playerTwo)
        {
            int totalTurns = 3;

            for (int i = 1; i <= totalTurns; i++)
            {
                // cw: simtxtgen.playerturnmessage(playerone)
                int playerOneScore = ScoreCalculator.CalculateTurnScore();
                playerOne.AddTurnScore(playerOneScore);
                // cw: simtxtgen.playerturnscoremessage(playerone, playeroneturnscore)

                // cw: simtxtgen.playerturnmessage(playertwo)
                int playerTwoScore = ScoreCalculator.CalculateTurnScore();
                playerTwo.AddTurnScore(playerTwoScore);
                // cw: simtxtgen.playerturnscoremessage(playertwo, playertwoturnscore)
            }

            // cw: simtxtgen.finalscoremessage(playerone, playeronescore)
            // cw: simtxtgen.finalscoremessage(playertwo, playertwoscore)

            Player winner = ScoreCalculator.DetermineWinner(playerOne, playerTwo);
            // cw: simtxtgen.winnermessage(winner)
        }
    }
}
