using System;
using System.Linq;
using System.Collections.Generic;
using ATextBasedAdventure.General.Interfaces;

namespace ATextBasedAdventure.General
{
    class ItemList : List<Item>
    {
        public string Describe()
        {
            string contents = "";

            if(this.Count == 0)
            {
                contents = "nothing.";
            }
            else
            {
                foreach(Item item in this)
                {
                    contents += item.Description + "; ";
                }
            }

            return contents;
        }

        public Item ThisObject(string _ItemName)
        {
            Item item = null;

            string itemLower = _ItemName.Trim().ToLower();

            item = this.FirstOrDefault(i => i.Name.Trim().ToLower() == itemLower);

            return item;
        }
    }
}
