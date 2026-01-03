using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Application.DTO
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Text { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
