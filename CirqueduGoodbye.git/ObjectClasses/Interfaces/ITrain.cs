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
        public IReadOnlyList<ITrainWagon> WagonList { get; }
        public void LoadWagons(List<IAnimal> animals);
        public void AddWagon(ITrainWagon wagon);
    }
}
