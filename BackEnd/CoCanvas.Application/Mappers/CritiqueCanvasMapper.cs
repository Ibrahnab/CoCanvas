using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoCanvas.Application.DTO;
using CoCanvas.Domain.Entities;

namespace CoCanvas.Application.Mappers
{
    public static class CritiqueCanvasMapper
    {
        public static CritiqueCanvasDto ToDto(CritiqueCanvas canvas)
        {
            return new CritiqueCanvasDto
            {
                CritiqueId = canvas.CritiqueId,
                CanvasJson = canvas.CanvasJson,
            };
        }
    }
}
