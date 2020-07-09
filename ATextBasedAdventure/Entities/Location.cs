using System;
using System.Text;
using System.Collections.Generic;
using ATextBasedAdventure.Entities.Interfaces;

namespace ATextBasedAdventure.Entities
{
    // A location will be anywhere in the game where the character
    // has an interaction, an encounter, or has a decision to make.
    class Location : Describable
    {
        // List of connections to other locations. This will contain id's of the locations that are connected.
        public Dictionary<Directions, Location> ConnectedLocations;

    }
}
