using ApplicationCore.Interfaces;
using ApplicationCore.ObjectClasses;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Animal = DataAccessLayer.Models.Animal;

namespace DataAccessLayer
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly CirqueduGoodbyeContext _dbContext;

        public AnimalRepository(CirqueduGoodbyeContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<IAnimal> GetAnimals()
        {
            List<Animal> animals = _dbContext.Animals.ToList();
            List<Carnivore> carnivores = animals.Where(y => y.Type == "Carnivore").Select(x => new Carnivore(x.Name, x.Size, x.Id)).ToList();
            List<Herbivore> herbivores = animals.Where(y => y.Type == "Herbivore").Select(x => new Herbivore(x.Name, x.Size, x.Id)).ToList();
            List<IAnimal> objectAnimals = new List<IAnimal>();
            objectAnimals.AddRange(carnivores);
            objectAnimals.AddRange(herbivores);
            return objectAnimals;
        }

        public bool AddAnimal(string name, int size, string type, int circusId)
        {
            _dbContext.Animals.Add(new Animal() { Name = name, Size = size, Type = type, CircusId = circusId });
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteAnimal(IAnimal animal)
        {
            _dbContext.Animals.Remove(_dbContext.Animals.FirstOrDefault(x => x.Id == animal.Id)!);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
