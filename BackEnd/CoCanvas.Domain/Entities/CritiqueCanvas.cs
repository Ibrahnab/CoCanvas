using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Domain.Entities
{
    public class CritiqueCanvas
    {   
        public Guid CritiqueId { get; set; }
        public string CanvasJson { get; set; } = string.Empty;
        public Critique Critique { get; set; } = null!;
    }
}
