//using CoCanvas.Infrastructure.Persistance;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using CoCanvas.Application.DTO;

//namespace CoCanvas.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PostsController : ControllerBase
//    {
//        private readonly CCDbContext _context;

//        public PostsController(CCDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/posts
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts()
//        {
//            var posts = await _context.Posts
//                .Include(p => p.Critiques)
//                    .ThenInclude(c => c.Comments)
//                        .ThenInclude(cm => cm.Replies)
//                .ToListAsync();

//            var dtos = posts.Select(MapToDto).ToList();
//            return Ok(dtos);
//        }
//    }

//        // GET: api/posts/{id}
//    [HttpGet("{id}")]
//        public async Task<ActionResult<PostDto>> GetPost(Guid id)
//        {
//            var post = await _context.Posts
//                .Include(p => p.Critiques)
//                    .ThenInclude(c => c.Comments)
//                        .ThenInclude(cm => cm.Replies)
//                .FirstOrDefaultAsync(p => p.Id == id);

//            if (post == null) return NotFound();

//            return Ok(MapToDto(post));
//        }

//    }
