using ApplicationCore.Interfaces;
using System.Drawing;

namespace ApplicationCore.ObjectClasses
{
    public class Animal : Interfaces.IAnimal
    {
        public Animal(string name, int size)
        {
            this.size = size;
            this.name = name;
        }
        
        private string name;
        private int size;

        //Encapsulation
        public string Name { get { return name; } set { name = value; } }
        public int Size { get { return size; } set { size = value; } }
    }
}