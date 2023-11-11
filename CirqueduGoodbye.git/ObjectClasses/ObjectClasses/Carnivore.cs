using ApplicationCore.Interfaces;

namespace ApplicationCore.ObjectClasses
{
    public class Carnivore : Animal
    {
        public Carnivore(string name, int size) : base(name, size)
        {
        }

        //SOLID single responsibility
        public bool WillEatAnimal(IAnimal animal)
        {
            return (this.Size >= animal.Size);
        }

        //SOLID single responsibility
        public bool WillEatAnyAnimal(List<IAnimal> animals)
        {
            bool willEat = false;
            foreach(Animal animal in animals)
            {
                if(this.Size >= animal.Size)
                {
                    willEat = true;
                    break;
                }
            }
            return willEat;
        }
    }
}