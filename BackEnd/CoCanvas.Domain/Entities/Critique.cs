using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Domain.Entities
{
    public class Critique
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!; // navigation property
        public Guid PostId { get; set; }
        public Post Post { get; set; } = null!;
        public ICollection<Reply> Replies { get; set; } = [];
        public CritiqueCanvas? Canvas { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
