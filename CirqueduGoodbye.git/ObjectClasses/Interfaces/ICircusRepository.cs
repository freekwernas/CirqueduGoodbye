using ApplicationCore.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICircusRepository
    {
        public ICircus GetCircusById(int id);
    }
}
