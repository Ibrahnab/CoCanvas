using CoCanvas.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using CoCanvas.Domain.Entities;

namespace CoCanvas.Infrastructure.Repositories
{
    public class UserRepository
    {
        // TODO: Add logger
        private readonly ClaimsPrincipal _claimsPrincipal;
        private readonly CCDbContext _dbContext;

        
        
        /// <summary>
        ///  
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        public UserRepository(CCDbContext dbContext, ClaimsPrincipal claimsPrincipal) {

            _dbContext = dbContext;
            _claimsPrincipal = claimsPrincipal;


        }

        public  async Task<User> GetSelf()
        {
            string userId = _claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return await _dbContext.Users.FindAsync(userId);
        }
    }
}
