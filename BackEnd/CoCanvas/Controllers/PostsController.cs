using CoCanvas.Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using CoCanvas.Application.DTO;
using CoCanvas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoCanvas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly CCDbContext _context;

        public PostsController(CCDbContext context)
        {
            _context = context;
        }

        // GET: api/posts
        [HttpGet]
        public async Task<ActionResult<List<DisplayPostDto>>> GetPosts()
        {
            var posts = await _context.Posts.Select(post => new DisplayPostDto
            {
                ImageUrl = post.ImageUrl,
                PostId = post.Id,
                PostTitle = post.Title,
                CreatedAt = post.CreatedAt
            }).ToListAsync();

            return Ok(posts);
        }


        // GET: api/posts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPost(Guid id)
        {
            var post = await _context.Posts
                .Include(p => p.Critiques)
                    .ThenInclude(c => c.Comments)
                        .ThenInclude(cm => cm.Replies)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null) return NotFound();

            return Ok(MapToPostDto(post));
        }

        private PostDto MapToPostDto(Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                UserId = post.UserId,
                Title = post.Title,
                Description = post.Description,
                CreatedAt = post.CreatedAt,
                Critiques = post.Critiques.Select( critique => MapToCritiqueDto(critique)).ToList(),
                Tags = post.Tags.Select(tag => tag.Name).ToList(),

            };
        }

        private CritiqueDto MapToCritiqueDto(Critique critique)
        {
            return new CritiqueDto
            {
                Id = critique.Id,
                UserId = critique.UserId,
                Username = critique.User.UserName,
                Rating = critique.Rating,
                Comments = critique.Comments.Select(comment => MapToCommentDto(comment)).ToList(),
            };
        }

        private CommentDto MapToCommentDto(Comment comment) {
            return new CommentDto
            {
                Id = comment.Id,
                X = comment.X,
                Y = comment.Y,
                Text = comment.Text,
                Replies = comment.Replies.Select( reply => MapToReplyDto(reply)).ToList(),
            };
        }

        private ReplyDto MapToReplyDto(Reply reply) {

            return new ReplyDto
            {
                Id = reply.Id,
                UserId = reply.UserId,
                Username = reply.User.UserName,
                Text = reply.Text,
            };
        }

    }
}