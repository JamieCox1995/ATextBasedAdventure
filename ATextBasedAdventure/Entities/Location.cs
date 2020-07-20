using System;
using System.Text;
using System.Collections.Generic;
using ATextBasedAdventure.General;
using ATextBasedAdventure.General.Interfaces;

namespace ATextBasedAdventure.Entities
{
    // A location will be anywhere in the game where the character
    // has an interaction, an encounter, or has a decision to make.
    class Location : Item
    {
        // List of connections to other locations. This will contain id's of the locations that are connected.
        public Dictionary<Directions, Location> ConnectedLocations;

        public ItemList _Items = new ItemList();

    }
}
