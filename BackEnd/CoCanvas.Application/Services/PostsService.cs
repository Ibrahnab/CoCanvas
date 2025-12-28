using CoCanvas.Application.Mappers;
using CoCanvas.Infrastructure.Persistance;
using CoCanvas.Application.DTO;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Application.Services
{
    public class PostsService
    {
        private CCDbContext _CCDbContext;
        // TODO: Inject logger
        
        public PostsService(CCDbContext db)
        {
            _CCDbContext = db;
        }

        public async Task<PostDto> GetPost(Guid guid)
        {

            var post = await _CCDbContext.Posts
            .Include(p => p.Critiques)
                .ThenInclude(c => c.Comments)
                    .ThenInclude(cm => cm.Replies)
            .FirstOrDefaultAsync(p => p.Id == guid);

            return PostMapper.ToDto(post);

        }
    }
}
