using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoCanvas.Domain.Entities;
using CoCanvas.Application.DTO;
using CoCanvas.Application.Mappers;

namespace CoCanvas.Application.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToDto(Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                X = comment.X,
                Y = comment.Y,
                Text = comment.Text,
            };
        }
    }
}
