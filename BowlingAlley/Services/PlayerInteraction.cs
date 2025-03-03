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

            // Display list of members from PlayerRepo?

            Console.Write("Player one, enter your name: ");
            string playerOne = Console.ReadLine();

            // Check if playerOne is a member

            Console.Write("Player two, enter your name: ");
            string playerTwo = Console.ReadLine();

            // Check if playerTwo is a member
        }

        // Handles player choice to register a new member from main menu
        private void RegisterNewMember()
        {
            Console.Write("Enter your name to register as a member: ");
            string name = Console.ReadLine();

            // Check for possible duplicates and register new member

            // Display message to confirm registration
        }

        // Exits the game
        private void ExitGame()
        {
            Console.WriteLine("Thank you for playing at Jessica's Bowling Alley!");
            Environment.Exit(0);
        }
    }
}
