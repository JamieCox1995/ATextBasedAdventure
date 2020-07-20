using System;
using System.Collections.Generic;
using System.Text;

namespace ATextBasedAdventure.General.Interfaces
{
    interface IDescribable
    {
        void Describe();
    }

    public class Item : IDescribable
    {
        public string Name;
        public string Description;

        public bool CanTake;

        public Item()
        {

        }

        public Item(string _Name, string _Description)
        {
            Name = _Name;
            Description = _Description;

            CanTake = false;
        }

        public Item(string _Name, string _Description, bool _CanTake)
        {
            Name = _Name;
            Description = _Description;
            CanTake = _CanTake;
        }

        public void Describe()
        {
            Console.WriteLine(Description);

            Console.WriteLine("What would you like to do?");
        }
    }
}
