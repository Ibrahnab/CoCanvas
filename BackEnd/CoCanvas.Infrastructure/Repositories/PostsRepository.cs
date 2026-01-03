using CoCanvas.Infrastructure.Persistance;
using CoCanvas.Application.Interfaces.Repositories;
using CoCanvas.Application.DTO;
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

        public async Task<PostDto?> GetPost(Guid guid)
        {
            // TODO: Revise this maybe, looks like a very loaded request, maybe ok though
            var post = await _dbContext.Posts
                .Where(p => p.Id == guid)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Rating = p.Rating,
                    Username = p.User.UserName,
                    UserId = p.User.Id,
                    ImageUrl = p.ImageUrl,
                    CreatedAt = p.CreatedAt,
                    Tags = p.Tags.Select( t => t.Name).ToList(),
                    Critiques = p.Critiques.Select(c => new CritiqueDto
                    {
                        Id = c.Id,
                        Username = c.User.UserName,
                        UserId = c.UserId,
                        Rating = c.Rating,
                        CreatedAt = c.CreatedAt,
                        Comments = c.Comments.Select(
                            com => new CommentDto
                            {
                                Id = com.Id,
                                X = com.X,
                                Y = com.Y,
                                Text = com.Text,
                                CreatedAt = com.CreatedAt,
                            }).ToList(),
                        Replies = c.Replies.Select(r => new ReplyDto
                        {
                            Id = r.Id,
                            Text = r.Text,
                            Username = r.User.UserName,
                            UserId = r.UserId,
                            CreatedAt = r.CreatedAt
                        }).ToList()
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return post;
        }

        public async Task<List<Post>> GetPosts()
        {
            // TODO: dont do this, get by time and chunks
            return await _dbContext.Posts.ToListAsync();
        }

        // TODO: Really Post?
        public async Task CreatePost(Post post)
        {
            await _dbContext.AddAsync(post);
            await _dbContext.SaveChangesAsync();
        }
    }
}
