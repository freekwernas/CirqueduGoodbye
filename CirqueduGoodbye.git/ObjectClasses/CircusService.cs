using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class CircusService : ICircusService
    {
        private readonly ICircusRepository _circusRepository;

        public CircusService(ICircusRepository circusRepository)
        {
            _circusRepository = circusRepository;
        }

        public ICircus GetCircusById(int id)
        {
            return _circusRepository.GetCircusById(id);
        }
    }
}
