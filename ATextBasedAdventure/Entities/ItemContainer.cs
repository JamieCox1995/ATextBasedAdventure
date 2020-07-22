using System;
using System.Collections.Generic;
using ATextBasedAdventure.General;
using ATextBasedAdventure.General.Interfaces;

namespace ATextBasedAdventure.Entities
{
    class ItemContainer : Item
    {
        private ItemList _Items = new ItemList();

        public bool CanOpen = false;

        public ItemContainer(string _Name, string _Description, ItemList _Items) : base(_Name, _Description)
        {
            this._Items = _Items;
        }

        public ItemContainer(string _Name, string _Description, ItemList _Items, bool _CanOpen) : base(_Name, _Description)
        {
            this._Items = _Items;
            CanOpen = _CanOpen;
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
