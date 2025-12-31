using CoCanvas.Application.DTO;
using CoCanvas.Application.Mappers;
using CoCanvas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Application.Mappers
{
    public static class PostMapper
    {
        public static PostDto ToDto(Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                UserId = post.UserId,
                Title = post.Title,
                Description = post.Description,
                CreatedAt = post.CreatedAt,
                ImageUrl = post.ImageUrl,
                Critiques = post.Critiques.Select(critique => CritiqueMapper.ToDto(critique)).ToList(),
                Tags = post.Tags.Select(tag => tag.Name).ToList(),

            };
        }

        // TODO: Consider instead, create a getter in the postsRepository that gets DisplayPost?
        public static DisplayPostDto ToDisplayPostDto(Post post)
        {
            return new DisplayPostDto
            {
                ImageUrl = post.ImageUrl,
                PostId = post.Id,
                PostTitle = post.Title,
                CreatedAt = post.CreatedAt
            };
        }
    }
}
