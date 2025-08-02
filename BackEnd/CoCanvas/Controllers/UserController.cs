using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CoCanvas.Domain.Entities;

namespace CoCanvas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = new List<User> {
                new User {
                    Email = "sample1@gmail.com",
                    Password = "Pass123!",
                },
                new User {
                    Email = "sample@gmail.com",
                    Password = "Pass123!",
                }
            };
            return Ok(users);
        }
    }
}
