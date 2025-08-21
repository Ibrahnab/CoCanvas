using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Application.DTO
{
    public class ReplyDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Text { get; set; } = null!;
    }

}
