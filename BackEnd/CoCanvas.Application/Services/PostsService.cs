using CoCanvas.Application.DTO;
using CoCanvas.Application.Interfaces;
using CoCanvas.Application.Interfaces.Repositories;
using CoCanvas.Application.Mappers;
using CoCanvas.Domain.Entities;
using Microsoft.AspNetCore.Http;
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
        // TODO: Inject logger

        private IPostsRepository _postsRepository;
        private ITagRepository _tagRepository;
        private IFileService _fileService;
        public PostsService(IPostsRepository postsRepository, ITagRepository tagRepository, IFileService fileService)
        {
            _postsRepository = postsRepository;
            _tagRepository = tagRepository;
            _fileService = fileService;
        }

        public async Task<PostDto?> GetPost(Guid guid)
        {
            // Done
            var result = await _postsRepository.GetPost(guid);

            if(result != null)
            {
                return PostMapper.ToDto(result);
            }   
            return null;
        }

        public async Task<PostDto> CreatePost(IFormFile image, CreatePostDto dto)
        {
            var fileName = await _fileService.SaveImageAsync(image);
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
                // Will check if it exists already, maybe update the name
                await _tagRepository.CreateTag(tagName);
            }

            // TODO: Can this fail?
            await _postsRepository.CreatePost(post);

            return PostMapper.ToDto(post);
        }

        // TODO: Create more specific getters
        public async Task<List<DisplayPostDto>> GetPosts()
        {
            var posts = await _postsRepository.GetPosts();
            var postDtos = new List<DisplayPostDto>();
            foreach (Post post in posts)
            {
                postDtos.Add(PostMapper.ToDisplayPostDto(post));
            }
            return postDtos;
        }
    }
}
