using System;
using System.Collections.Generic;
using ATextBasedAdventure.General;
using ATextBasedAdventure.General.Interfaces;

namespace ATextBasedAdventure.Entities
{
    class ItemContainer : Item
    {
        private ItemList _Items = new ItemList();

        public ItemContainer(string _Name, string _Description, ItemList _Items) : base(_Name, _Description)
        {
            this._Items = _Items;
        }

        public ItemList Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        public void AddItem(Item _Item)
        {
            _Items.Add(_Item);
        }

        public void AddItems(ItemList _Items)
        {
            this._Items.AddRange(_Items);
        }

        public new void Describe()
        {
            Console.WriteLine($"The {Name}, {Description} contains {_Items.Describe()}");
        }
    }
}
