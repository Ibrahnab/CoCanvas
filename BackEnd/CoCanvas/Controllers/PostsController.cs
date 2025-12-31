using CoCanvas.Application.DTO;
using CoCanvas.Application.Interfaces;
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
        private readonly PostsService _postsService;
        private readonly IFileService _fileService;
        public PostsController(PostsService postsService, IFileService fileService)
        {
            _postsService = postsService;
            _fileService = fileService;
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
        public  ActionResult GetImage(string fileName)
        {
            var fileData = _fileService.GetImageAsync(fileName);

            if (fileData == null)
            {
                return NotFound();
            }
            return File(fileData.Stream, fileData.ContentType);
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