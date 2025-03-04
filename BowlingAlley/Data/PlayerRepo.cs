using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BowlingAlley.Core;

namespace BowlingAlley.Data
{
    public class PlayerRepo: IPlayerRepo
    {
        private readonly string filePath = "Data/members.json";
        private List<Player> players;

        public PlayerRepo()
        {
            players = LoadPlayers();
        }

        private List<Player> LoadPlayers()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
                return new List<Player>();
            }

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Player>>(json) ?? new List<Player>();
        }

        private void SavePlayers()
        {
            var json = JsonConvert.SerializeObject(players, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void AddPlayer(Player player)
        {
            if (!players.Any(p => p.Name == player.Name))
            {
                players.Add(player);
                SavePlayers();
            }
            else
            {
                throw new InvalidOperationException("Player already exists.");
            }
        }

        public Player? GetPlayer(string name)
        {
            return players.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Player> GetAllPlayers()
        {
            return new List<Player>(players);
        }
    }
}
