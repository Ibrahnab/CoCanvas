using CoCanvas.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace CoCanvas.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("me")]
    public class MeController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public MeController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetMe()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(new
            {
                user.Id,
                user.Email,
                user.UserName
            });
        }
    }
}