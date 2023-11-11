using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ObjectClasses
{
    public class TrainWagon : ITrainWagon
    {
        //Encapsulation
        private int capacity;
        public int Capacity { get { return capacity; } set { capacity = value; } }
        //SOLID Dependency inversion
        public List<IAnimal> Animals { get; set; } = new List<IAnimal> { };
        public TrainWagon(int capacity)
        {
            this.capacity = capacity;
        }

        //SOLID single responsibility
        public bool CapcityBreached(IAnimal animal)
        {
            return ((Animals.Sum(animal => animal.Size) + animal.Size) > Capacity);
        }

        public override string ToString()
        {
            string animalsList = string.Empty;
            foreach(Animal animal in Animals)
            {
                animalsList += animal.Name + ", ";
            }
            return animalsList.Substring(0, animalsList.Length - 2);
        }
    }
}
