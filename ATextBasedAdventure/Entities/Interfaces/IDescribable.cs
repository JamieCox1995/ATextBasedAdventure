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

        public void Describe()
        {
            Console.WriteLine(Description);
        }
    }
}
