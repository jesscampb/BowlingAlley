using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAlley.Services
{
    class PlayerInteraction
    {

        // Displays when console application starts
        // Sets in motion the game choices
        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Jessica's Bowling Alley!\n");
            Console.WriteLine("Please select an option:\n");
            Console.WriteLine("1. Start New Game");
            Console.WriteLine("2. Register a member");
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
                    HandleRegisterMember();
                    break;

                case 3:
                    ExitGame();
                    break;
            }
        }

        // Handles player choice to start a new game from main menu
        private void HandleStartGame()
        {
            Console.WriteLine("Make your choice:\n");
            Console.WriteLine("1. Pick your name from the member list");
            Console.WriteLine("2. Play as a guest");

            int choice = GetPlayerChoice(2);

            switch (choice)
            {
                case 1:
                    ChooseMemberFromList();
                    break;
                case 2:
                    HandleGuestPlayer();
                    break;
            }
        }

        // Start game with member
        private void ChooseMemberFromList()
        {
            Console.WriteLine("Choose a member from the list below by entering the name:\n");
            // Display list of members
            // Get member choice
        }

        // Start game with guest player
        private void HandleGuestPlayer()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
        }

        // Handles player choice to register a new member from main menu
        private void HandleRegisterMember()
        {
            Console.Write("Enter your name to register as a member and start playing: ");
            string name = Console.ReadLine();
            // Register member
        }

        // Exits the game
        private void ExitGame()
        {
            Console.WriteLine("Thank you for playing at Jessica's Bowling Alley!");
            Environment.Exit(0);
        }
    }
}
