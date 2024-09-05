using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserLogin.Models;

namespace UserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserDbContext _dbcontext;
        public RegisterController(UserDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost]
        [Route("Register")]
        public  async Task<IActionResult> Registeruser([FromBody] User user)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var u1 = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Name  == user.Name);
            if (u1 == null) 
            {
               
                _dbcontext.Add(user);
                await _dbcontext.SaveChangesAsync();
                return Ok("Registered Sucessfully ...!");
            }
            return BadRequest("Username Already Registered ... ! ");
            
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _dbcontext.Users.ToListAsync();
            return Ok(users);
        }
    }
}
