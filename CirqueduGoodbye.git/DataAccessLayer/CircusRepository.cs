using ApplicationCore.Interfaces;
using ApplicationCore.ObjectClasses;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CircusRepository : ICircusRepository
    {
        private readonly CirqueduGoodbyeContext _dbContext;

        public CircusRepository(CirqueduGoodbyeContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public ICircus GetCircusById(int id)
        {
            return _dbContext.Circus.Where(x => x.Id == id ).Select(x => new ApplicationCore.ObjectClasses.Circus(x.Id)).FirstOrDefault() ?? throw new ArgumentNullException(nameof(_dbContext));
        }
    }
}
