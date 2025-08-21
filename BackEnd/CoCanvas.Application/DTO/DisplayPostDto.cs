using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Application.DTO
{
    public class DisplayPostDto
    {
        public string ImageUrl { get; set; } = null!;
        public Guid PostId { get; set; }
        public string PostTitle { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

    }
}
