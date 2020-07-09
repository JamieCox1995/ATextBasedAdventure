using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using ATextBasedAdventure.Entities;
using ATextBasedAdventure.Entities.Locations;

namespace ATextBasedAdventure
{
    class Game
    {
        public static List<Location> Locations = new List<Location>();

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
        }

        public void ConstructWorld()
        {
            Locations.Add(new Location
            {
                Name = "Heirloom Sphere: Entrance",
                Description = "You are stood in a large, cavernous room with smooth walls that taper to a point above the centre of the room.",

                ConnectedLocations = new Dictionary<Directions, Location>()
            });

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
            
            if(userCommand.ToLower() == "quit")
            {
                Environment.Exit(0);
            }
            else if (userCommand.ToLower() == "help")
            {
                ShowUsefulCommands();
            }
            else
            {
                Console.WriteLine("\nCommand not recognised. Use the command \"help\" for a list of possible commands.\n");
            }

        }

        public void ShowUsefulCommands()
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