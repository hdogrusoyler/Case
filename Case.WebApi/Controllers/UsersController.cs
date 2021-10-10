using Case.BusinessLogic.Abstract;
using Case.Etity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Case.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserManager _userService;
        private IConfiguration _configuration;

        public UsersController(IUserManager userService, IConfiguration configuration)
        {
            _userService = userService; 
            _configuration = configuration;
        }

        [Route("Signin")]
        [HttpPost]
        public ActionResult Add([FromBody] User user)
        {
            var result = new User();

            if (user.Id == 0)
            {
                _userService.Add(user);
            }    

            return Ok(result);
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult Login([FromBody] User user)
        {
            var loginUser = _userService.Login(user);
            if (loginUser != null)
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
                SigningCredentials signincredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);
                ClaimsIdentity claimIdentity = new ClaimsIdentity(new Claim[]
                {
                //new Claim(ClaimTypes.NameIdentifier, userToken.Id.ToString()),
                new Claim(ClaimTypes.Role, loginUser.Role),
                new Claim(ClaimTypes.GivenName, loginUser.Name),
                });
                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = claimIdentity,
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = signincredentials
                };
                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                string userToken = tokenHandler.WriteToken(token);

                return Ok("Bearer "+userToken);
            }
            else
            {
                return Unauthorized();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult GetList()
        {
            return Ok(_userService.GetAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public ActionResult Get(int Id)
        {
            return Ok(_userService.GetById(Id));
        }

        [Authorize(Roles = "Admin")]
        [Route("Save")]
        [HttpPost]
        public ActionResult AddUpdate([FromBody] User user)
        {
            var result = new User();

            if (user.Id > 0)
            {
                _userService.Update(user);
            }
            else
            {
                _userService.Add(user);
            }

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [Route("Delete/{id}")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            return Ok(_userService.Delete(id));
        }



        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            user.Id = id;

            return Ok(_userService.Update(user));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            return Ok(_userService.Delete(id));
        }
    }
}
