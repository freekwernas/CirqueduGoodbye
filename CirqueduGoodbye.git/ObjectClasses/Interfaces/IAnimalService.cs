using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IAnimalService
    {
        public List<IAnimal> GetAnimals();
        public bool AddAnimal(string name, int size, string type, int circusId);

        public bool DeleteAnimal(IAnimal animal);
    }
}
