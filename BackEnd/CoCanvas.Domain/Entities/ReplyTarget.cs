using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Domain.Entities
{
    // TODO: Maybe use this later for Critique, Comment and Post?
    // Also consider renaming and adding more properties
    public abstract class Replyable
    {
        public Guid Id { get; set; }

        public ICollection<Reply> replies { get; set; } = new List<Reply>();
    }
}
