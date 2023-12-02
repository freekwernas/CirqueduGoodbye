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
        private readonly List<IAnimal> animals;
        public IReadOnlyList<IAnimal> Animals => animals.AsReadOnly();
        public TrainWagon(int capacity)
        {
            animals = new List<IAnimal>();
            this.capacity = capacity;
        }

        public bool TryAddAnimal(IAnimal animal)
        {
            if (animal.GetType() == typeof(Carnivore))
            {
                Carnivore carnivore = (Carnivore)animal;
                if (!CapcityBreached(carnivore) && !carnivore.WillEatAnyAnimal(animals))
                {
                    animals.Add(carnivore);
                    return true;
                }
            }
            else
            {
                Herbivore herbivore = (Herbivore)animal;
                if (!CapcityBreached(herbivore) && !herbivore.WillGetEatenAnyAnimal(animals))
                {
                    animals.Add(herbivore);
                    return true;
                }
            }
            return false;
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
