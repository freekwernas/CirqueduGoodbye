using ApplicationCore.Interfaces;
using ApplicationCore.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public bool AddAnimal(string name, int size, string type, int circusId)
        {
            return _animalRepository.AddAnimal(name, size, type, circusId);
        }

        public bool DeleteAnimal(IAnimal animal)
        {
            return _animalRepository.DeleteAnimal(animal);
        }

        public List<IAnimal> GetAnimals()
        {            
            return _animalRepository.GetAnimals();
        }
    }
}
