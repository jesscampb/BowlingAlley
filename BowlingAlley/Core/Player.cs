﻿namespace BowlingAlley.Core
{
    public class Player
    {
        public string Name { get; set; }
        public List<int> TurnScores { get; } = new List<int>();
        public int TotalScore => TurnScores.Sum();

        public Player(string name)
        {
            Name = name;
        }

        public void AddTurnScore(int score)
        {
            TurnScores.Add(score);
        }
    }
}
