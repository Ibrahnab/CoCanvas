
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoCanvas.Domain.Entities;
using CoCanvas.Application.DTO;

namespace CoCanvas.Application.Mappers
{
    public static class ReplyMapper
    {
        public static ReplyDto ToDto(Reply reply)
        {
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
