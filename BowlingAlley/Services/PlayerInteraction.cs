﻿using BowlingAlley.Core;
using BowlingAlley.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            List<Player> players = _playerRepo.GetAllPlayers();

            foreach (var player in players)
            {
                Console.WriteLine(player.Name);
            }

            // Player one registration
            Console.Write("Player one, enter your name: ");
            string playerOne = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(playerOne))
            {
                Console.WriteLine("Invalid input. Please enter a valid name.");
            }
            else
            {
                var playerOneObj = _playerRepo.GetPlayer(playerOne);

                if (playerOneObj == null)
                {
                    Console.WriteLine($"'{playerOne}' not found. Registering new member...");
                    _playerRepo.AddPlayer(new Player(playerOne));
                    Console.WriteLine($"Player '{playerOne}' registered successfully!");
                }
                else
                {
                    Console.WriteLine($"Player '{playerOne}' found!");
                }
            }

            // Player two registration (redunant code)
            Console.Write("Player two, enter your name: ");
            string playerTwo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(playerTwo))
            {
                Console.WriteLine("Invalid input. Please enter a valid name.");
            }
            else
            {
                var playerTwoObj = _playerRepo.GetPlayer(playerTwo);

                if (playerTwoObj == null)
                {
                    Console.WriteLine($"'{playerTwo}' not found. Registering new member...");
                    _playerRepo.AddPlayer(new Player(playerTwo));
                    Console.WriteLine($"Player '{playerTwo}' registered successfully!");
                }
                else
                {
                    Console.WriteLine($"Player '{playerTwo}' found!");
                }
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
