using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Text { get; set; } = string.Empty;

        public Guid CritiqueId { get; set; }
        public Critique Critique { get; set; } = null!;

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }

}
