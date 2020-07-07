using System;
using System.Text;
using System.Collections.Generic;
using ATextBasedAdventure.Entities.Interfaces;

namespace ATextBasedAdventure.Entities.Locations
{
    // A location will be anywhere in the game where the character
    // has an interaction, an encounter, or has a decision to make.
    class Location : Describable
    {
        // Name of the location; every location should have a unique name that makes it distinguishable from all the others
        public string LocationName;

        // List of connections to other locations. This will contain id's of the locations that are connected.
        public List<int> ConnectedLocations;
    }
}
