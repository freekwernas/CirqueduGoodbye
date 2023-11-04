using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ObjectClasses
{
    public  class Circus
    {
        public List<Animal> CircusAnimals { get; set; } 

        public Circus()
        {
            CircusAnimals = new List<Animal>();
        }

        public void AddAnimal(string name, int size, string type)
        {
            if (type == "Carnivore")
            {

                CircusAnimals.Add(new Carnivore(name, size));
            }
            else //since no other options
            {
                CircusAnimals.Add(new Herbivore(name, size));
            }
        }

        public int EquateSize(string size)
        {
            switch (size)
            {
                case "small":
                    return 1;
                case "medium":
                    return 3;
                case "large":
                    return 5;
            }
            return 0; //error state
        }

        public Train CalculateTrain()
        {
            Train train = new Train();
            train.LoadWagons(CircusAnimals);
            return train;
        }

    }
}
