using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ITrainWagon
    {
        public int Capacity { get; }
        public bool CapcityBreached(IAnimal animal);

        public IReadOnlyList<IAnimal> Animals { get; }

        public bool TryAddAnimal(IAnimal animal);
    }
}
