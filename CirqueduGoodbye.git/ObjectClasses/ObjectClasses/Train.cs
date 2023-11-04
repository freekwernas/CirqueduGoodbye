using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ObjectClasses
{
    public  class Train
    {
        public List<TrainWagon> WagonList { get; set; } = new List<TrainWagon> { };

        public Train() 
        {
            
        }

        public void LoadWagons(List<Animal> animals)
        {
            TrainWagon wagon = new TrainWagon(10);

            List<Animal> sortedAnimals = animals.OrderByDescending(x => x.Size).ToList();

            foreach (Animal animal in sortedAnimals.OfType<Herbivore>())
            {
                if(wagon.Capacity < (wagon.Animals.Sum(animal => animal.Size) + animal.Size)) // if capacity is not breached
                {
                    WagonList.Add(wagon); //add wagon to list before adding new wagon
                    wagon = new TrainWagon(10); //new wagon
                    wagon.Animals.Add(animal); //add animal
                }
                else
                {
                    wagon.Animals.Add(animal); //no new wagon needed
                }
            }
            WagonList.Add(wagon); // commit last wagon

            int wagonListWithHerbivores = WagonList.Count;
            foreach (Animal animal in sortedAnimals.OfType<Carnivore>())
            {
                bool animalAdded = false;
                for (int i = 0; i < wagonListWithHerbivores; i++)
                {
                
                    //if capacity is not breached OR if a smaller animal is present
                    if (WagonList[i].Capacity >= (WagonList[i].Animals.Sum(animal => animal.Size) + animal.Size) && !WagonList[i].Animals.Any(x => x.Size <= animal.Size) && !WagonList[i].Animals.OfType<Carnivore>().Any()) 
                    {
                        animalAdded = true;
                        WagonList[i].Animals.Add(animal);
                    }
                }
                if (!animalAdded) // in case the carnivore wasn't able to be added to a carriage.
                {
                    wagon = new TrainWagon(10);
                    wagon.Animals.Add(animal);
                    WagonList.Add(wagon);
                }
            }
        }
    }
}
