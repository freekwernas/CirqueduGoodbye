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

        public List<IAnimal> Animals { get; set; }
        public bool CapcityBreached(IAnimal animal);
    }
}
