using System;
using System.Linq;
using System.Collections.Generic;
using ATextBasedAdventure.General.Interfaces;

namespace ATextBasedAdventure.General
{
    class ItemList : List<Describable>
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
                foreach(Describable item in this)
                {
                    contents += item.Description + "; ";
                }
            }

            return contents;
        }

        public Describable ThisObject(string _ItemName)
        {
            Describable item = null;

            string itemLower = _ItemName.Trim().ToLower();

            item = this.FirstOrDefault(i => i.Name.Trim().ToLower() == itemLower);

            return item;
        }
    }
}
