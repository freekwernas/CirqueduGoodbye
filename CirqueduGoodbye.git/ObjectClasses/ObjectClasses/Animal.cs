using ApplicationCore.Interfaces;
using System.Drawing;

namespace ApplicationCore.ObjectClasses
{
    public class Animal : Interfaces.IAnimal
    {
        public Animal(string name, int size)
        {
            Size = size;
            Name = name;
        }


        public string Name { get; private set; }
        public int Size { get; private set; }
    }
}