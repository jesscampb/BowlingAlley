using BowlingAlley.Core;
using BowlingAlley.Services;
using Newtonsoft.Json;

namespace BowlingAlley.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly string filePath = "members.json";
        private readonly SingletonLogger _logger = SingletonLogger.Instance;
        private List<Player> players;

        public PlayerRepository()
        {
            players = LoadPlayers();
            Console.WriteLine("Current directory: " + Directory.GetCurrentDirectory());
        }

        private List<Player> LoadPlayers()
        {
            try
            {
                _logger.Log("Loading players from file...");

                if (!File.Exists(filePath))
                {
                    _logger.Log("No player data found. Creating new file.");
                    File.WriteAllText(filePath, "[]");
                    return new List<Player>();
                }

                var json = File.ReadAllText(filePath);
                players = JsonConvert.DeserializeObject<List<Player>>(json) ?? new List<Player>();

                _logger.Log("Players loaded successfully.");
                return players;
            }
            catch (Exception ex)
            {
                _logger.Log($"Error loading players: {ex.Message}");
                return new List<Player>();
            }
        }

        private void SavePlayers()
        {
            try
            {
                var json = JsonConvert.SerializeObject(players, Formatting.Indented);
                File.WriteAllText(filePath, json);

                _logger.Log("Players saved successfully.");
            }
            catch (Exception ex)
            {
                _logger.Log($"Error saving players: {ex.Message}");
            }
        }

        public void AddPlayer(Player player)
        {
            try
            {
                if (!players.Any(p => p.Name == player.Name))
                {
                    players.Add(player);
                    _logger.Log("Player added successfully.");

                    SavePlayers();
                }
                else
                {
                    _logger.Log("Player already exists.");
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Error adding player: {ex.Message}");
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
