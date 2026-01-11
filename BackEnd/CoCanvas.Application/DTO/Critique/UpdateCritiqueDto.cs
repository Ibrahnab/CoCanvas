using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Application.DTO.Critique
{
    public  class UpdateCritiqueDto
    {
        public string? Description { get; set; } = string.Empty;
        public List<CommentDto> Comments { get; set; } = new();
        public string CanvasJson { get; set; } = string.Empty;
    }
}
