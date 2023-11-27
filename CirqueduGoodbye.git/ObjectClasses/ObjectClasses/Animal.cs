using ApplicationCore.Interfaces;
using System.Drawing;

namespace ApplicationCore.ObjectClasses
{
    public class Animal : IAnimal
    {
        public Animal(string name, int size, int id)
        {
            this.size = size;
            this.name = name;
            this.id = id;
        }
        private int id;
        private string name;
        private int size;

        //Encapsulation
        public string Name { get { return name; } set { name = value; } }
        public int Size { get { return size; } set { size = value; } }
        public int Id { get { return id; } set { id = value; } }
    }
}