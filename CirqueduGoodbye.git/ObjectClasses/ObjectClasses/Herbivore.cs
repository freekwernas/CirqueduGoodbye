using ApplicationCore.Interfaces;

namespace ApplicationCore.ObjectClasses
{
    public class Herbivore : Animal
    {
        public Herbivore(string name, int size) : base(name, size)
        {
        }

        //SOLID single responsibility
        public bool WillGetEatenAnimal(IAnimal animal)
        {
            return (this.Size <= animal.Size);
        }

        //SOLID single responsibility
        public bool WillGetEatenAnyAnimal(IReadOnlyList<IAnimal> animals)
        {
            bool willGetEaten = false;
            if (animals.Any(x => x.GetType() == typeof(Carnivore)))
            {
                List<IAnimal> carnivores = animals.Where(x => x.GetType() == typeof(Carnivore)).ToList();
                foreach (Carnivore animal in carnivores)
                {
                    if (this.Size <= animal.Size)
                    {
                        willGetEaten = true;
                        break;
                    }
                }
            }
            return willGetEaten;
        }
    }
}