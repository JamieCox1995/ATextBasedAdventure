using System;
using System.Text;
using System.Collections.Generic;
using ATextBasedAdventure.Entities.Interfaces;

namespace ATextBasedAdventure.Entities.Locations
{
    class LocationConnection : Describable
    {
        public Location ConnectedLocation;
    }
}
