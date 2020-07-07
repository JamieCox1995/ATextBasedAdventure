using System;
using System.Collections.Generic;
using System.Text;

namespace ATextBasedAdventure.Entities
{
    class Character
    {
        // The character class is the base of all characters that are in the game, including the player.
        public string Name { get; private set; }

        public string Race { get; private set; }

        public string Class { get; private set; }

    }
}
