using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using ATextBasedAdventure.Entities;
using ATextBasedAdventure.General.Interfaces;

namespace ATextBasedAdventure
{
    class Game
    {
        public static List<Location> Locations = new List<Location>();

        public Character Player;

        private CommandParser CommandParser;
        private GameState _CurrentGameState;

        public bool IsRunning
        {
            get
            {
                return _CurrentGameState != GameState.Quit;
            }
        }

        public Game()
        {
            InitializeGame();
        }

        public void InitializeGame()
        {
            _CurrentGameState = GameState.MainMenu;

            ConstructWorld();

            Locations[0].Describe();

            Player = new Character("Steve", "A normal human", Locations[0]);

            this.CommandParser = new CommandParser();
            this.CommandParser.InitializeParser(this);
        }

        public void ConstructWorld()
        {
            Locations.Add(new Location
            {
                Name = "Heirloom Sphere: Entrance",
                Description = "You are stood in a large, cavernous room with smooth walls that taper to a point above the centre of the room.",

                ConnectedLocations = new Dictionary<Directions, Location>(),

                
            });

            Locations[0]._Items.Add(new Item("Sword", "an ancient sword of magical origins.", true));

            Locations.Add(new Location
            {
                Name = "Heirloom Sphere: The Grand Library",
                Description = "The room is vast with rows upon rows of bookshelves, all filled with books.",

                ConnectedLocations = new Dictionary<Directions, Location> { { Directions.South, Locations[0] } }
            });

            Locations[0].ConnectedLocations.Add(Directions.North, Locations[1]);


        }

        public void Update()
        {
            string userCommand = Console.ReadLine();

            CommandParser.ParseCommand(userCommand, null);
        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        public void Save()
        {
            Console.WriteLine("Attempting to save game...");
        }

        public void Help()
        {
            ShowUsefulCommands();
        }

        private void ShowUsefulCommands()
        {
            Console.WriteLine($"\nUseful Commands: \n " +
                $"\"help\" -> lists useful commands \n " +
                $"\"quit\" -> close the game \n " +
                $"\"move\" [direction] -> moves ");

        }
    }

    public enum GameState
    {
        MainMenu,
        CharacterCreation,
        Running,
        Quit
    }
}