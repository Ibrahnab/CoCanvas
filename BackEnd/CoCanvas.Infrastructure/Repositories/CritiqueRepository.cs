using CoCanvas.Application.DTO;
using CoCanvas.Application.Interfaces.Repositories;
using CoCanvas.Domain.Entities;
using CoCanvas.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Infrastructure.Repositories
{
    public  class CritiqueRepository : ICritiqueRepository
    {
        private CCDbContext _dbContext;
        public CritiqueRepository(CCDbContext dbContext) {
            
            _dbContext = dbContext;

        }

        public async Task AddAsync(Critique critique)
        {
            await _dbContext.AddAsync(critique);
            await _dbContext.SaveChangesAsync();
        }
    }
}
