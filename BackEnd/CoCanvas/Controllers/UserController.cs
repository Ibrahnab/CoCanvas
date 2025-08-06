using CoCanvas.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace CoCanvas.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/auth")]
    public class MeController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public MeController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
        [HttpGet("me")]
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

        // This doesn't work, for now, just discard the token and make it short-lived
        [Authorize]
        [HttpPost("logout")]
        public async Task<IResult> Logout([FromBody] object empty)
        {

            Console.WriteLine("entered logout");
            if (empty != null)
            {
                Console.WriteLine("Attempting to sign out");
                await _signInManager.SignOutAsync();
                await HttpContext.SignOutAsync(IdentityConstants.BearerScheme);
                return Results.Ok();
            }
            return Results.Unauthorized();
        }
    }
}