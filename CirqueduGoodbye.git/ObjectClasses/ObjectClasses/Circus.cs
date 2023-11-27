using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ObjectClasses
{
    public  class Circus : ICircus
    {
        public List<IAnimal> CircusAnimals { get; set; }

        private int id;

        //Encapsulation
        public int Id { get { return id; } set { id = value; } }

        public Circus(int id)
        {
            CircusAnimals = new List<IAnimal>();
            Id = id;
        }

        //public void AddAnimal(string name, int size, string type, int id)
        //{
        //    if (type == "Carnivore")
        //    {

        //        CircusAnimals.Add(new Carnivore(name, size, id));
        //    }
        //    else //since no other options
        //    {
        //        CircusAnimals.Add(new Herbivore(name, size, id));
        //    }
        //}

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
