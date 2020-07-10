using System;
using System.Text;
using System.Collections.Generic;
using ATextBasedAdventure.Entities;

namespace ATextBasedAdventure
{
    class CommandParser
    {
        public static Dictionary<string, WordType> Vocabulary;

        public static void ParseCommand(string _InputString, Character _PlayerCharacter)
        {
            if (string.IsNullOrWhiteSpace(_InputString)) return;

            string[] deliminated = _InputString.Split(new char[2] { ' ', '.' });

            for (int index = 0; index < deliminated.Length; index++)
            {
                deliminated[0] = deliminated[0].ToLower();
            }

            ConstructCommandTypes(deliminated);
        }

        private static void ConstructCommandTypes(string[] _ParsedWords)
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

        private static void ProcessCommands(List<CommandWord> _Commands)
        {

        }

    }

    class CommandWord
    {
        public string Word;
        public WordType WordType;
    }

    enum WordType
    {
        Adjective,
        Article,
        Conjunction,
        Error,
        Preposition,
        Noun,
        Unknown,
        Verb
    }
}
