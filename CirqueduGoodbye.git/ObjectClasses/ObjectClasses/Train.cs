using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ObjectClasses
{
    public  class Train : ITrain
    {
        //SOLID Dependency inversion
        public List<ITrainWagon> WagonList { get; set; } = new List<ITrainWagon> { };

        public Train() 
        {
            
        }

        public void LoadWagons(List<IAnimal> animals)
        {
            List<IAnimal> sortedAnimals = animals.OrderByDescending(x => x.Size).ToList();

            foreach (Animal animal in sortedAnimals.OfType<Carnivore>())
            {               
                TrainWagon wagon = new TrainWagon(10);
                wagon.Animals.Add(animal); //add animal
                WagonList.Add(wagon); //add wagon to list before adding new wagon
                
            }

            int wagonList = WagonList.Count;
            foreach (Herbivore animal in sortedAnimals.OfType<Herbivore>())
            {
                bool animalAdded = false;
                for (int i = 0; i < wagonList; i++)
                {

                    //if capacity is not breached OR if a same size or bigger animal is present of type carnivore
                    if (!WagonList[i].CapcityBreached(animal) && !animal.WillGetEatenAnyAnimal(WagonList[i].Animals))
                    {
                        animalAdded = true;
                        WagonList[i].Animals.Add(animal);
                        break;
                    }
                }
                if (!animalAdded) // in case the carnivore wasn't able to be added to a carriage.
                {
                    TrainWagon wagon = new TrainWagon(10);
                    wagon.Animals.Add(animal);
                    WagonList.Add(wagon);
                    wagonList++;
                }
            }
        }
    }
}
