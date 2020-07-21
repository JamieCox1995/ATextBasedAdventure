using System;
using System.Text;
using System.Collections.Generic;
using ATextBasedAdventure.Entities;

namespace ATextBasedAdventure
{
    class CommandParser
    {
        public Dictionary<string, WordType> Vocabulary;             // Dictionary that stores all words in the game.

        private Game _Game;                                         // Reference to the game, so we can access methods to save/quit etc.
        private Character _Character;                               // Reference to the Player's character. This is so we can access methods to pickup, look, attack etc.

        public void InitializeParser(Game _Game)
        {
            // When we initialise the command parser, we want to create the Vocabulary dictionary with all of our Command Verbs (take, drop, attack, etc), and words for Preposition (into, at, etc)
            InitializeVocabulary();

            this._Game = _Game;
            _Character = _Game.Player;
        }

        private void InitializeVocabulary()
        {
            Vocabulary = new Dictionary<string, WordType>();

            /*--------------------------------------------------------------------------------------
             * TODO: This is where we are going to manually add all of the 
             * Utility keywords, such as Help, Quit, or save. These are core commands that we 
             * want the user to be able to type to be able to access anywhere any time
             --------------------------------------------------------------------------------------*/
            Vocabulary.Add("help", WordType.Utility);
            Vocabulary.Add("quit", WordType.Utility);
            Vocabulary.Add("save", WordType.Utility);
            Vocabulary.Add("inventory", WordType.Utility);

            /*--------------------------------------------------------------------------------------
             * TODO: This is where we are going to manually add all of the 
             * COMMANDS, such as Take, Drop, Attack
             --------------------------------------------------------------------------------------*/
            Vocabulary.Add("take", WordType.Verb);
            Vocabulary.Add("pickup", WordType.Verb);
            Vocabulary.Add("drop", WordType.Verb);
            Vocabulary.Add("move", WordType.Verb);
            Vocabulary.Add("look", WordType.Verb);

            /*--------------------------------------------------------------------------------------
             * TODO: This is where we are going to manually add all of the 
             * Adverbs, such as 'around'
             --------------------------------------------------------------------------------------*/
            Vocabulary.Add("around", WordType.Adverb);

            /*--------------------------------------------------------------------------------------
             * TODO: This is where we are going to manually add all of the 
             * Prepositions, such as "in", "into", "at"
             --------------------------------------------------------------------------------------*/
            Vocabulary.Add("in", WordType.Preposition);
            Vocabulary.Add("into", WordType.Preposition);
            Vocabulary.Add("at", WordType.Preposition);

            /*--------------------------------------------------------------------------------------
             * TODO: This is where we are going to manually add all of the 
             * Articles, such as "a", "an", "the"
             --------------------------------------------------------------------------------------*/
            Vocabulary.Add("a", WordType.Article);
            Vocabulary.Add("an", WordType.Article);
            Vocabulary.Add("the", WordType.Article);

            /*--------------------------------------------------------------------------------------
             * TODO: This is where we are going to manually add all of the 
             * Nouns, such as "game". This is so that we can type commands
             * such as "save game" or "quit game"
             --------------------------------------------------------------------------------------*/
            Vocabulary.Add("game", WordType.Noun);
            Vocabulary.Add("north", WordType.Noun);
            Vocabulary.Add("east", WordType.Noun);
            Vocabulary.Add("south", WordType.Noun);
            Vocabulary.Add("west", WordType.Noun);

            // Now we are going to populate all of the Nouns and adjectives. These will be populated by getting all of the Describable Objects
            Vocabulary.Add("sword", WordType.Noun);
        }

        public void ParseCommand(string _InputString, Character _PlayerCharacter)
        {
            if (string.IsNullOrWhiteSpace(_InputString)) return;

            string[] deliminated = _InputString.Split(new char[2] { ' ', '.' });

            for (int index = 0; index < deliminated.Length; index++)
            {
                deliminated[0] = deliminated[0].ToLower();
            }

            ConstructCommandTypes(deliminated);
        }

        private  void ConstructCommandTypes(string[] _ParsedWords)
        {
            List<CommandWord> commandWords = new List<CommandWord>();
            WordType currentWordType;
            bool containsUnknownWord = false;

            foreach(string word in _ParsedWords)
            {
                if(Vocabulary.ContainsKey(word))
                {
                    currentWordType = Vocabulary[word];

                    if (currentWordType != WordType.Article)
                    {
                        commandWords.Add(new CommandWord() { Word = word, WordType = currentWordType });
                    }
                }
                else
                {
                    containsUnknownWord = true;
                }
            }

            if(!containsUnknownWord)
            {
                ProcessCommands(commandWords);
            }
        }

        private void ProcessCommands(List<CommandWord> _Commands)
        {
            if(_Commands.Count != 0)
            {
                switch (_Commands.Count)
                {
                    case 1:
                        ProcessSingleWordCommand(_Commands);
                        break;

                    case 2:
                        ProcessDualWordCommand(_Commands);
                        break;

                    case 3:
                        ProcessTriWordCommand(_Commands);
                        break;

                    case 4:
                        ProcessQuadWordCommand(_Commands);
                        break;

                    default:
                        Console.WriteLine("Command Type is not yet supported.");
                        break;
                }
            }
        }

        #region Process Commands
        private void ProcessSingleWordCommand(List<CommandWord> _Commands)
        {
            if(_Commands[0].WordType == WordType.Utility)
            {
                switch(_Commands[0].Word)
                {
                    case "help":
                        _Game.Help();
                        break;

                    case "quit":
                        _Game.Quit();
                        break;

                    case "save":
                        _Game.Save();
                        break;

                    case "inventory":
                        _Character.LookAtInventory();
                        break;
                }
            }
        }

        private void ProcessDualWordCommand(List<CommandWord> _Commands)
        {
            // Checking to see if the user has entered "save game" or "quit game"
            if(_Commands[0].WordType == WordType.Utility)
            {
                if (_Commands[1].Word == "game")
                {
                    switch(_Commands[0].Word)
                    {
                        case "save":
                            _Game.Save();
                            break;

                        case "quit":
                            _Game.Quit();
                            break;
                    }
                }
            }

            // Processing commands such as take x, drop x, open x, etc.
            if(_Commands[0].WordType == WordType.Verb)
            {
                CommandWord verb = _Commands[0];
                CommandWord word = _Commands[1];


                if (word.WordType == WordType.Noun)
                {                    
                    switch(verb.Word)
                    {
                        case "take":
                            _Character.PickupItem(word.Word);
                            break;

                        case "drop":
                            _Character.DropItem(word.Word);
                            break;

                        case "move":
                            _Character.MoveDirection(word.Word);
                            break;
                    }

                    return;
                }

                if(word.WordType == WordType.Adverb)
                {
                    switch(verb.Word)
                    {
                        case "look":
                            if (word.Word == "around") _Character.LookAround();
                            break;
                    }

                    return;
                }
            }
        }

        private void ProcessTriWordCommand(List<CommandWord> _Commands)
        {

        }

        private void ProcessQuadWordCommand(List<CommandWord> _Commands)
        {

        }
        #endregion
    }

    class CommandWord
    {
        public string Word;
        public WordType WordType;
    }

    enum WordType
    {
        Adjective,
        Adverb,
        Article,
        Conjunction,
        Error,
        Preposition,
        Noun,
        Unknown,
        Utility,
        Verb
    }
}
