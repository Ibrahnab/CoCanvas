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

            // TODO: Handle errors
            var postDto = await _postsService.CreatePost(image, dto);
            
            return CreatedAtAction(nameof(GetPost), new { id = postDto.Id }, postDto);
        }

        // GET: api/posts
        [HttpGet]
        public async Task<ActionResult<List<DisplayPostDto>>> GetPosts()
        {
            // TODO: Handle case where nothing is returned;
            var result = await _postsService.GetPosts();
            return Ok(result);
        }

        [HttpGet("images/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            // TODO: Call the file service
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
    }
}