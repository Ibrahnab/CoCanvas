using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCanvas.Application.DTO;

namespace CoCanvas.Application.DTO
{
    public class CritiqueDto
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public List<CommentDto> Comments { get; set; } = new();
        public List<ReplyDto> Replies { get; set; } = new();
    }

}
