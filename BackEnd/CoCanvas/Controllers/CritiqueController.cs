using CoCanvas.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoCanvas.Api.Controllers
{
    [Route("api/critiques")]
    [ApiController]
    public class CritiqueController : ControllerBase
    {

        public CritiqueController()
        {
            // TODO: Add services
        }


        [HttpPut("{critiqueId}")]
        public Task<IActionResult> UpdateCritique(Guid critiqueId, CritiqueDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
