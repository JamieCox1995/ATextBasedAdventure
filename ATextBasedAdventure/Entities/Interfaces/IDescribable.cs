using System;
using System.Collections.Generic;
using System.Text;

namespace ATextBasedAdventure.Entities.Interfaces
{
    interface IDescribable
    {
        void Describe();
    }

    public class Describable : IDescribable
    {
        public string Name;
        public string Description;

        public Describable()
        {

        }

        public Describable(string _Name, string _Description)
        {
            Name = _Name;
            Description = _Description;
        }

        public void Describe()
        {
            Console.WriteLine(Description);

            Console.WriteLine("What would you like to do?");
        }
    }
}
