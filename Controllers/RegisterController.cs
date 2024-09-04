using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Registeruser(string Username,string Email  ,string Password)

        {
            User u1 = _dbcontext.Users.FirstOrDefault(x => x.Name  == Username);
            if (u1 == null) 
            {
                var reg = new User()
                {
                    Name = Username,
                    Email = Email,
                    Password = Password
                };
                _dbcontext.Add(reg);
                _dbcontext.SaveChanges();
                return Ok("Registered Sucessfully ...!");
            }
            return BadRequest("Username Already Registered ... ! ");
            
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var user = _dbcontext.Users.ToList();
            return Ok(user);
        }
    }
}
