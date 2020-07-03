using System;

namespace ATextBasedAdventure
{
    class Program
    {
        private static Game _Game;

        static void Main(string[] args)
        {
            Initialize();

            while(_Game.IsRunning)
            {
                _Game.Update();
            }
        }

        private static void Initialize()
        {
            Console.Title = "A Text Based Adventure";

            _Game = new Game();
        }
    }
}
