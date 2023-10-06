using JWT_Escola.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Escola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UsuarioLogin request)
        {
            var user = Authenticate(request);

            if (user is not null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        private string Generate(UsuarioEscola user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Email, user.EmailAdress),
                new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth),
                new Claim(ClaimTypes.MobilePhone, user.MobilePhone),
                new Claim(ClaimTypes.Gender, user.Gender),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UsuarioEscola Authenticate(UsuarioLogin request)
        {
            var currentUser = UsuarioBDFake.UsuariosBD.FirstOrDefault(
                u => u.Username.ToLower() == request.Username.ToLower() &&
                u.Password == request.Password);

            if (currentUser is not null)
            {
                return currentUser;
            }
            return null;
        }
    }
}
