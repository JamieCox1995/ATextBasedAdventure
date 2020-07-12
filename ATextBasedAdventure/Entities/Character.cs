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

        public void MoveDirection(Directions _MoveDirection)
        {
            if(_MoveDirection != Directions.Unknown)
            {
                if(_CurrentLocation.ConnectedLocations[_MoveDirection] != null)
                {
                    _CurrentLocation = _CurrentLocation.ConnectedLocations[_MoveDirection];
                    _CurrentLocation.Describe();
                }
                else
                {
                    Console.WriteLine($"There is no location to the {_MoveDirection}");
                }
            }
        }

        public void MoveDirection(string _MoveDirection)
        {
            if(!string.IsNullOrWhiteSpace(_MoveDirection))
            {
                Directions moveDirection;

                switch(_MoveDirection)
                {
                    case "n":
                    case "north":
                        moveDirection = Directions.North;
                        break;

                    case "e":
                    case "east":
                        moveDirection = Directions.East;
                        break;

                    case "s":
                    case "south":
                        moveDirection = Directions.South;
                        break;

                    case "w":
                    case "west":
                        moveDirection = Directions.West;
                        break;

                    default:
                        moveDirection = Directions.Unknown;
                        break;
                }

                MoveDirection(moveDirection);
            }
        }
    }
}
