using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Application.DTO
{
    public class CritiqueCanvasDto
    {
        public Guid CritiqueId { get; set; }

        public string CanvasJson { get; set; } = string.Empty;
    }
}
