using ApplicationCore.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ITrain
    {
        public List<ITrainWagon> WagonList { get; set; }
        public void LoadWagons(List<IAnimal> animals);
    }
}
