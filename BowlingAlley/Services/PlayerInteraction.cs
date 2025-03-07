using BowlingAlley.Core;
using BowlingAlley.Data;
using BowlingAlley.Factories;

namespace BowlingAlley.Services
{
    class PlayerInteraction
    {
        private readonly IPlayerRepository _playerRepo;

        public PlayerInteraction(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }


        // Displays when console application starts
        public void WelcomeMessage()
        {
            Console.WriteLine($"{Environment.NewLine}Welcome to Jessica's Bowling Alley!");

            DisplayMainMenu();
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine($"{Environment.NewLine}Please select an option:");
            Console.WriteLine($"{Environment.NewLine}1. Start new game");
            Console.WriteLine("2. Register as a member");
            Console.WriteLine("3. Exit");

            int choice = GetPlayerChoice(3);

            HandleMainMenuChoice(choice);
        }

        public void DisplayPostGameMenu()
        {
            Console.WriteLine($"{Environment.NewLine}What would you like to do?");
            Console.WriteLine($"{Environment.NewLine}1. Start a new game");
            Console.WriteLine("2. Return to main menu");
            Console.WriteLine("3. Exit");

            int choice = GetPlayerChoice(3);

            HandlePostGameMenuChoice(choice);

        }

        // Handles player menu number input
        private int GetPlayerChoice(int maxChoice)
        {
            int choice = 0;
            bool isValidChoice = false;

            while (!isValidChoice)
            {
                Console.Write($"{Environment.NewLine}Enter your choice: ");
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

        public void HandlePostGameMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    HandleStartGame();
                    break;

                case 2:
                    DisplayMainMenu();
                    break;

                case 3:
                    ExitGame();
                    break;
            }
        }


        // Handles player choice to start a new game from main menu
        private void HandleStartGame()
        {
            Console.WriteLine($"{Environment.NewLine}You need a membership to start a game of bowling! If your name isn't on the list of " +
                "existing members, you will be signed up automatically.");
            Console.WriteLine($"{Environment.NewLine}For your reference, here are the members currently registered at Jessica's Bowling Alley.\n");

            List<Player> players = _playerRepo.GetAllPlayers();

            foreach (var player in players)
            {
                Console.WriteLine(player.Name);
            }

            Player playerOne = GetOrRegisterPlayer($"{Environment.NewLine}Player one, enter your name: ");
            Player playerTwo = GetOrRegisterPlayer($"{Environment.NewLine}Player two, enter your name: ");

            SelectGameModeAndStart(playerOne, playerTwo);
        }

        private void SelectGameModeAndStart(Player playerOne, Player playerTwo)
        {
            Console.WriteLine($"{Environment.NewLine}Last step! Please select a game mode:");
            Console.WriteLine($"{Environment.NewLine}1. Quick Game (1 round)");
            Console.WriteLine("2. Normal Game (3 rounds)");

            int choice = GetPlayerChoice(2);

            Game game = GameFactory.CreateGame(playerOne, playerTwo, choice);

            game.StartGame();

            DisplayPostGameMenu();
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
                    Console.WriteLine($"Invalid input. Please enter a valid name.");
                    continue;
                }

                var playerObj = _playerRepo.GetPlayer(playerName);

                if (playerObj == null)
                {
                    Console.WriteLine($"'{playerName}' not found. Registering new member...");
                    playerObj = new Player(playerName);
                    _playerRepo.AddPlayer(playerObj);
                    SingletonLogger.Instance.Log($"New member registered: {playerName}.");
                    Console.WriteLine($"Member '{playerName}' registered successfully!");
                    Console.WriteLine($"{Environment.NewLine}Player '{playerName}' joined the game!");
                }
                else
                {
                    Console.WriteLine($"'{playerName}' found. Welcome back!");
                    SingletonLogger.Instance.Log($"Member '{playerName}' signed in.");
                    Console.WriteLine($"{Environment.NewLine}Player '{playerName}' joined the game!");
                }

                return playerObj;
            }
        }


        // Handles player choice to register a new member from main menu
        private void RegisterNewMember()
        {
            while (true)
            {
                Console.Write($"{Environment.NewLine}Enter your name to register: ");
                string nameInput = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(nameInput))
                {
                    Console.WriteLine("Invalid input. Please enter a valid name.");
                    continue;
                }

                var playerObj = _playerRepo.GetPlayer(nameInput);

                if (playerObj != null)
                {
                    Console.WriteLine("Member already exists. Please try a different name.");
                }
                else
                {
                    _playerRepo.AddPlayer(new Player(nameInput));
                    Console.WriteLine($"{Environment.NewLine}Successfully registered '{nameInput}' as a member. Welcome!");
                    break;
                }
            }
            Console.WriteLine($"{Environment.NewLine}Press any key to return to the main menu.");
            Console.ReadKey();
            DisplayMainMenu();
        }


        // Exits the game
        private void ExitGame()
        {
            Console.WriteLine($"{Environment.NewLine}Thank you for playing at Jessica's Bowling Alley!");
            Environment.Exit(0);
        }
    }
}
