using System;
using System.Text;
using System.Collections.Generic;
using ATextBasedAdventure.Entities.Locations;
using ATextBasedAdventure.Entities.Interfaces;

namespace ATextBasedAdventure.Entities
{
    class Character : Describable
    {
        private Location _CurrentLocation;

        public Character(string _name, string _description, Location _location) : base(_name, _description)
        { 
            _CurrentLocation = _location;
        }

        public void TravserseLocation(int _locationID)
        {
            if (_locationID != -1)
            {
                Console.WriteLine("Cannot move to room");
            }
            else
            {
                Location playersNewLocation = Game.Locations[_locationID];

                _CurrentLocation = playersNewLocation;

                _CurrentLocation.Describe();
            }
        }

        public void TraverseLocation(string _locationName)
        {

        }

        public void TraverseLocation(Location _newLocation)
        {

        }
    }
}
