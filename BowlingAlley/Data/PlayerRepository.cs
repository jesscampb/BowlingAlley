using BowlingAlley.Core;
using BowlingAlley.Services;
using Newtonsoft.Json;

namespace BowlingAlley.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly string _filePath;
        private readonly SingletonLogger _logger = SingletonLogger.Instance;
        private List<Player> _players;

        public PlayerRepository()
        {
            _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BowlingAlley", "members.json");
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath));

            _players = LoadPlayers();
        }

        private List<Player> LoadPlayers()
        {
            try
            {
                _logger.Log("Loading players from file...");

                if (!File.Exists(_filePath))
                {
                    _logger.Log("No player data found. Creating new file.");
                    File.WriteAllText(_filePath, "[]");
                    return new List<Player>();
                }

                var json = File.ReadAllText(_filePath);
                _players = JsonConvert.DeserializeObject<List<Player>>(json) ?? new List<Player>();

                _logger.Log("Players loaded successfully.");
                return _players;
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
                var json = JsonConvert.SerializeObject(_players, Formatting.Indented);
                File.WriteAllText(_filePath, json);

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
                if (!_players.Any(p => p.Name == player.Name))
                {
                    _players.Add(player);
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
            return _players.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Player> GetAllPlayers()
        {
            return new List<Player>(_players);
        }
    }
}
