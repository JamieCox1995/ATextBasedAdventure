﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using ATextBasedAdventure.Entities;

namespace ATextBasedAdventure
{

    class Game
    {
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

            Console.WriteLine(" █████      ████████ ███████ ██   ██ ████████      █████  ██████  ██    ██ ███████ ███    ██ ████████ ██    ██ ██████  ███████ ");
            Console.WriteLine("██   ██        ██    ██       ██ ██     ██        ██   ██ ██   ██ ██    ██ ██      ████   ██    ██    ██    ██ ██   ██ ██      ");
            Console.WriteLine("███████        ██    █████     ███      ██        ███████ ██   ██ ██    ██ █████   ██ ██  ██    ██    ██    ██ ██████  █████   ");
            Console.WriteLine("██   ██        ██    ██       ██ ██     ██        ██   ██ ██   ██  ██  ██  ██      ██  ██ ██    ██    ██    ██ ██   ██ ██      ");
            Console.WriteLine("██   ██        ██    ███████ ██   ██    ██        ██   ██ ██████    ████   ███████ ██   ████    ██     ██████  ██   ██ ███████ ");
        }

        public void Update()
        {
            switch(_CurrentGameState)
            {

            }
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