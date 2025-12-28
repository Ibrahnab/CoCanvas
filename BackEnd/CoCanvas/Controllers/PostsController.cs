using CoCanvas.Application.DTO;
using CoCanvas.Application.Mappers;
using CoCanvas.Application.Services;
using CoCanvas.Domain.Entities;
using CoCanvas.Infrastructure.Persistance;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;

namespace CoCanvas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly CCDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly PostsService _postsService;
        public PostsController(CCDbContext context, IWebHostEnvironment  env, PostsService postsService )
        {
            _context = context;
            _env = env;
            _postsService = postsService;
        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePost([FromForm] IFormFile image, [FromForm] CreatePostDto dto)
        {
            // TODO: Do these things outside of the controller
            var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine("wwwroot/images", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var post = new Post
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                ImageUrl = fileName,
                UserId = dto.UserId,
                Tags = new List<Tag>()
            };

            foreach (var tagName in dto.Tags)
            {
                var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tagName);
                if (tag == null)
                {
                    tag = new Tag { Id = Guid.NewGuid(), Name = tagName };
                    _context.Tags.Add(tag);
                }
                post.Tags.Add(tag);
            }

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, PostMapper.ToDto(post));
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

        [HttpGet("images/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            var filePath = Path.Combine(_env.ContentRootPath, "wwwroot/images", fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();
            var image = System.IO.File.OpenRead(filePath);
            return File(image, "image/jpeg");
        }


        // GET: api/posts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPost(Guid id)
        {
            //var post = await _context.Posts
            //    .Include(p => p.Critiques)
            //        .ThenInclude(c => c.Comments)
            //            .ThenInclude(cm => cm.Replies)
            //    .FirstOrDefaultAsync(p => p.Id == id);

            //if (post == null) return NotFound();

            //return Ok(MapToPostDto(post));

            var result = await _postsService.GetPost(id); 
            if ( result == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(result);
            }
        }

        //// TODO: Move these to a mapper service?
        //private PostDto MapToPostDto(Post post)
        //{
        //    return new PostDto
        //    {
        //        Id = post.Id,
        //        UserId = post.UserId,
        //        Title = post.Title,
        //        Description = post.Description,
        //        CreatedAt = post.CreatedAt,
        //        ImageUrl = post.ImageUrl,
        //        Critiques = post.Critiques.Select( critique => MapToCritiqueDto(critique)).ToList(),
        //        Tags = post.Tags.Select(tag => tag.Name).ToList(),

        //    };
        //}

        //private CritiqueDto MapToCritiqueDto(Critique critique)
        //{
        //    return new CritiqueDto
        //    {
        //        Id = critique.Id,
        //        UserId = critique.UserId,
        //        Username = critique.User.UserName,
        //        Rating = critique.Rating,
        //        Comments = critique.Comments.Select(comment => MapToCommentDto(comment)).ToList(),
        //    };
        //}

        //private CommentDto MapToCommentDto(Comment comment) {
        //    return new CommentDto
        //    {
        //        Id = comment.Id,
        //        X = comment.X,
        //        Y = comment.Y,
        //        Text = comment.Text,
        //        Replies = comment.Replies.Select( reply => MapToReplyDto(reply)).ToList(),
        //    };
        //}

        //private ReplyDto MapToReplyDto(Reply reply) {

        //    return new ReplyDto
        //    {
        //        Id = reply.Id,
        //        UserId = reply.UserId,
        //        Username = reply.User.UserName,
        //        Text = reply.Text,
        //    };
        //}

    }
}