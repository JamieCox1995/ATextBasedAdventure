using System;
using System.Text;
using System.Collections.Generic;
using ATextBasedAdventure.Entities.Interfaces;

namespace ATextBasedAdventure.Entities.Locations
{
    // This is used at locations
    class LocationList : Dictionary<string, Location>, IDescribable
    {
        public Location ConnectionAt(string id)
        {
            return this[id];
        }

        public void Describe()
        {

            if (this.Count == 0)
            {
                Console.WriteLine("The room appears to be a dead end.");
            }
            else
            {
                string description = "";

                foreach (KeyValuePair<string, Location> connection in this)
                {
                    description += $"{connection.Value.Description} + \r\n";
                }

                Console.WriteLine(description);
            }
        }
    }
}
