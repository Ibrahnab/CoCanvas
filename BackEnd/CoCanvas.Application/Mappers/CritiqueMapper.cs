using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoCanvas.Application.Mappers;
using CoCanvas.Application.DTO;
using CoCanvas.Domain.Entities;

namespace CoCanvas.Application.Mappers
{
    public static class CritiqueMapper
    {

        public static CritiqueDto ToDto(Critique critique)
        {
            return new CritiqueDto
            {
                Id = critique.Id,
                UserId = critique.UserId,
                Username = critique.User.UserName,
                Rating = critique.Rating,
                Comments = critique.Comments.Select(comment => CommentMapper.ToDto(comment)).ToList(),
            };
        }
    }
}
