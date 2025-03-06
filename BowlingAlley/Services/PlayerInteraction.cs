using BowlingAlley.Core;
using BowlingAlley.Data;
using BowlingAlley.Factories;

namespace BowlingAlley.Services
{
    class PlayerInteraction
    {
        private readonly IPlayerRepo _playerRepo;

        public PlayerInteraction(IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }


        // Displays when console application starts
        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Jessica's Bowling Alley!\n");
            Console.WriteLine("Please select an option:\n");
            Console.WriteLine("1. Start new game");
            Console.WriteLine("2. Register as a member");
            Console.WriteLine("3. Exit");

            int choice = GetPlayerChoice(3);

            HandleMainMenuChoice(choice);
        }


        // Handles player menu number input
        private int GetPlayerChoice(int maxChoice)
        {
            int choice = 0;
            bool isValidChoice = false;

            while (!isValidChoice)
            {
                Console.Write("Enter your choice: ");
                string userInput = Console.ReadLine();
                isValidChoice = int.TryParse(userInput, out choice) && choice >= 1 && choice <= maxChoice;

                if (!isValidChoice)
                {
                    Console.WriteLine($"Invalid input. Please enter a number between 1 and {maxChoice}.");
                }
            }
            return choice;
        }


        // Handles player main menu choice
        public void HandleMainMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    HandleStartGame();
                    break;

                case 2:
                    RegisterNewMember();
                    break;

                case 3:
                    ExitGame();
                    break;
            }
        }


        // Handles player choice to start a new game from main menu
        private void HandleStartGame()
        {
            Console.WriteLine("You need a membership to start a game of bowling! If your name isn't on the list of " +
                "existing members, your name will be registered automatically.\n");
            Console.WriteLine("For your reference, here are the members currently registered at Jessica's Bowling Alley.\n");

            List<Player> players = _playerRepo.GetAllPlayers();

            foreach (var player in players)
            {
                Console.WriteLine(player.Name);
            }

            Player playerOne = GetOrRegisterPlayer("Player one, enter your name: ");
            Player playerTwo = GetOrRegisterPlayer("Player two, enter your name: ");

            SelectGameModeAndStart(playerOne, playerTwo);
        }

        private void SelectGameModeAndStart(Player playerOne, Player playerTwo)
        {
            Console.WriteLine("Last step! Please select a game mode:");
            Console.WriteLine("1. Quick Game (1 round)");
            Console.WriteLine("2. Normal Game (3 rounds)");

            int choice = GetPlayerChoice(2);

            Game game = GameFactory.CreateGame(playerOne, playerTwo, choice);

            game.StartGame();
        }

        // Gets player name and registers new member if not found
        private Player GetOrRegisterPlayer(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string playerName = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(playerName))
                {
                    Console.WriteLine("Invalid input. Please enter a valid name.");
                    continue;
                }

                var playerObj = _playerRepo.GetPlayer(playerName);

                if (playerObj == null)
                {
                    Console.WriteLine($"'{playerName}' not found. Registering new member...");
                    playerObj = new Player(playerName);
                    _playerRepo.AddPlayer(new Player(playerName));
                    Console.WriteLine($"Player '{playerName}' registered successfully!");
                }
                else
                {
                    Console.WriteLine($"Player '{playerName}' found!");
                }

                return playerObj;
            }
        }


        // Handles player choice to register a new member from main menu
        private void RegisterNewMember()
        {
            Console.Write("Enter your name to register as a member: ");
            string nameInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(nameInput))
            {
                Console.WriteLine("Invalid input. Please enter a valid name.");
                return;
            }

            var playerObj = _playerRepo.GetPlayer(nameInput);

            if (playerObj != null)
            {
                Console.WriteLine("Member already exists.");
                return;
            }

            _playerRepo.AddPlayer(new Player(nameInput));
            Console.WriteLine($"Successfully registered '{nameInput}' as a member. Welcome!");
        }


        // Exits the game
        private void ExitGame()
        {
            Console.WriteLine("Thank you for playing at Jessica's Bowling Alley!");
            Environment.Exit(0);
        }
    }
}
