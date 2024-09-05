using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Loginuser(User loginrequest)
        {
            var u1  = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Name == loginrequest.Name && x.Password == loginrequest.Password);
            if (u1 == null)
            {
                return Unauthorized("Username and Password Unmatched...!");
            }
            return Ok("Login Successfully....!"); 
        }
    }
}
