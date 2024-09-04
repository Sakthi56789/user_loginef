using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserLogin.Models;

namespace UserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDbContext _dbcontext;
        public LoginController (UserDbContext dbcontext)
        {
            _dbcontext = dbcontext; 
        }
        [HttpGet]
        [Route("Login")]
        public IActionResult Loginuser(string Username,string Password)
        {
            User u1  = _dbcontext.Users.FirstOrDefault(x => x.Name == Username && x.Password == Password);
            if (u1 == null)
            {
                return Unauthorized("Username and Password Unmatched...!");
            }
            return Ok("Login Successfully....!");
        }
    }
}
