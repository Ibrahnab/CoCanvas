using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoCanvas.Application.DTO;
using CoCanvas.Domain.Entities;

namespace CoCanvas.Application.Mappers
{
    public static class CanvasMapper
    {
        public static CanvasDto ToDto(Canvas canvas)
        {
            return new CanvasDto
            {
                Id = canvas.Id,
                PostId = canvas.PostId,
                UserId = canvas.UserId,
                CanvasJson = canvas.CanvasJson,
            };
        }
    }
}
