using ApplicationCore.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICircus
    {
        int Id { get; }
        public List<IAnimal> CircusAnimals { get; set; }

        //public void AddAnimal(string name, int size, string type, int id);

        public int EquateSize(string size);

        public Train CalculateTrain();
    }
}
