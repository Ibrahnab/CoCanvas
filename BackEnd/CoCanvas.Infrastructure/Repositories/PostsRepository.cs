using CoCanvas.Infrastructure.Persistance;
using CoCanvas.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCanvas.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CoCanvas.Infrastructure.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private CCDbContext _dbContext;

        public PostsRepository(CCDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<Post> GetPost(Guid guid)
        {
            var post = await _dbContext.Posts
            .Include(p => p.Critiques)
                .ThenInclude(c => c.Comments)
                    .ThenInclude(cm => cm.Replies)
            .FirstOrDefaultAsync(p => p.Id == guid);

            return post;
        }

        public async Task<List<Post>> GetPosts()
        {
            // TODO: dont do this
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task CreatePost(Post post)
        {
            await _dbContext.AddAsync(post);
            await _dbContext.SaveChangesAsync();
        }
    }
}
