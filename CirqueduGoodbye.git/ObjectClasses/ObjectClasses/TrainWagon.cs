using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ObjectClasses
{
    public class TrainWagon
    {
        public int Capacity { get; }

        public List<Animal> Animals { get; set; } = new List<Animal> { };
        public TrainWagon(int capacity)
        {
            Capacity = capacity;
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
