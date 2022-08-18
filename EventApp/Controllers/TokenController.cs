using Event.Application;
using Event.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] GetUser.Request users, [FromServices] GetUser getUser)
        {
            if(users != null && users.Name != null && users.Password != null)
            {
                var userData = getUser.Do(users.Name, users.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                if (userData == null)
                    return BadRequest("Invalid user data");
                    
                var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        //new Claim("Id", users.Id.ToString()),
                        new Claim("Name", users.Name),
                        new Claim("Password", users.Password),
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signIn
                    );

                return Ok($"Bearer {new JwtSecurityTokenHandler().WriteToken(token)}");
            }
            else
                return BadRequest("Invalid user data");
        }
    }
}
