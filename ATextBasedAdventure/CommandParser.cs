using System;
using System.Text;
using System.Collections.Generic;
using ATextBasedAdventure.Entities;

namespace ATextBasedAdventure
{
    class CommandParser
    {
        public static void ParseCommand(string _InputString, Character _PlayerCharacter)
        {
            string[] deliminated = _InputString.Split(new char[2] { ' ', '.' });
        }

    }
}
