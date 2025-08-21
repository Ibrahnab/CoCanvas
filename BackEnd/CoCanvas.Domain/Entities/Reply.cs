using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Domain.Entities
{
    public class Reply
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;


        public Guid CommentId { get; set; }
        public Comment Comment { get; set; } = null!;
    }
}
