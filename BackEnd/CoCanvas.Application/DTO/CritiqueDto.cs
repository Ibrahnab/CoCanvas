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
        public string UserId { get; set; } = null!;
        public string Username { get; set; } = null!;
        public int Rating { get; set; }
        public List<CommentDto> Comments { get; set; } = new();
    }

}
