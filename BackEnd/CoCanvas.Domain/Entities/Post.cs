using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Image storage (either file path, URL, or blob reference)
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<Critique> Critiques { get; set; } = new();
        public List<Tag> Tags { get; set; } = new();
    }
}
