using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoCanvas.Domain.Entities;

namespace CoCanvas.Application.Interfaces.Repositories
{
    public interface ICritiqueRepository
    {
        public Task AddAsync(Critique critique);
    }
}
