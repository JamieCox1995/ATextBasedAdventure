using System;
using System.Text;
using System.Collections.Generic;
using ATextBasedAdventure.General;
using ATextBasedAdventure.General.Interfaces;

namespace ATextBasedAdventure.Entities
{
    class Character : Item
    {
        public ItemList _Items = new ItemList();

        private Location _CurrentLocation;

        public Character(string _name, string _description, Location _location) : base(_name, _description)
        { 
            _CurrentLocation = _location;
        }

        #region Navigate Around World
        public void MoveDirection(Directions _MoveDirection)
        {
            if(_MoveDirection != Directions.Unknown)
            {
                if(_CurrentLocation.ConnectedLocations.ContainsKey(_MoveDirection))
                {
                    _CurrentLocation = _CurrentLocation.ConnectedLocations[_MoveDirection];
                    _CurrentLocation.Describe();
                }
                else
                {
                    Console.WriteLine($"There is nothing to the {_MoveDirection}");
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
        #endregion

        public void LookAround()
        {
            if(_CurrentLocation != null)
            {
                _CurrentLocation.Describe();
                Console.WriteLine($"In in the room you see {_CurrentLocation._Items.Describe()}");
            }
        }

        public void LookAtInventory()
        {
            Console.WriteLine($"Your inventory contains {_Items.Describe()}");
        }

        public void LookAtItem(string _ItemName)
        {
            Item lookAtTarget = _CurrentLocation._Items.ThisObject(_ItemName);

            if(_ItemName == "")
            {
                Console.WriteLine("Please enter an item you want to look at.");
            }
            else
            {
                if(lookAtTarget == null)
                {
                    Console.WriteLine($"There is no {_ItemName}");
                }
                else
                {
                    lookAtTarget.Describe();
                }
            }
        }

        #region Picking up and Dropping Objects

        public void PickupItem(string _ItemName)
        {
            Item item = _CurrentLocation._Items.ThisObject(_ItemName);

            if (_ItemName != "")
            {
                if (item == null)
                {
                    Console.WriteLine($"There is no {_ItemName} here.");
                }
                else
                {
                    if (item.CanTake)
                    {
                        MoveItem(item, _CurrentLocation._Items, _Items);

                        Console.WriteLine($"You have picked up the {_ItemName}");
                    }
                    else
                    {
                        Console.WriteLine("You cannot take that item.");
                    }
                }
            }
        }

        public void PickupItem(Item _Item, ItemList _Container)
        {

        }

        public void MoveItem(Item _Item, ItemList _FromContainer, ItemList _ToContainer)
        {
            _FromContainer.Remove(_Item);
            _ToContainer.Add(_Item);
        }

        public void DropItem(string _ItemName)
        {
            Item item = _Items.ThisObject(_ItemName);

            if(_ItemName == "")
            {
                Console.WriteLine("Please enter an item name.");
                return;
            }

            if (item == null)
            {
                Console.WriteLine("You do not have any.");
            }
            else
            {
                MoveItem(item, _Items, _CurrentLocation._Items);
                Console.WriteLine($"You have dropped the {_ItemName}");
            }

        }

        public void DropItem(Item _Item)
        {

        }
        #endregion

        public bool SearchForItemInInventory(string _ItemName, out Item _Item)
        {
            _Item = null;

            return true;
        }
    }
}
