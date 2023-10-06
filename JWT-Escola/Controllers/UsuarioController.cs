using JWT_Escola.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace JWT_Escola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpGet("Diretor")]
        [Authorize(Roles = "Diretor")]
        public IActionResult DiretorEndpoints()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Bem vindo {currentUser.Role}(a) {currentUser.Name}\n" +
                      $"Dados do Usuario:\n" +
                      $"Email: {currentUser.EmailAdress}\n" +
                      $"Data de nascimento {currentUser.DateOfBirth}\n" +
                      $"Gênero : {currentUser.Gender}\n" +
                      $"Celular : {currentUser.MobilePhone}");
        }

        [HttpGet("Professor")]
        [Authorize(Roles = "Professor")]
        public IActionResult ProfessorEndpoints()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Bem vindo {currentUser.Role}(a) {currentUser.Name}\n" +
                      $"Dados do Usuario:\n" +
                      $"Email: {currentUser.EmailAdress}\n" +
                      $"Data de nascimento {currentUser.DateOfBirth}\n" +
                      $"Gênero : {currentUser.Gender}\n" +
                      $"Celular : {currentUser.MobilePhone}");
        }

        [HttpGet("DiretorEProfessor")]
        [Authorize(Roles = "Diretor,Professor")]
        public IActionResult DirEProfEndpoints()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Bem vindo {currentUser.Role}(a) {currentUser.Name}\n" +
                      $"Dados do Usuario:\n" +
                      $"Email: {currentUser.EmailAdress}\n" +
                      $"Data de nascimento {currentUser.DateOfBirth}\n" +
                      $"Gênero : {currentUser.Gender}\n" +
                      $"Celular : {currentUser.MobilePhone}"); ;
        }

        [HttpGet("Alunos")]
        public IActionResult AlunosEndpoints()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Bem vindo {currentUser.Role}(a) {currentUser.Name}\n" +
                      $"Dados do Usuario:\n" +
                      $"Email: {currentUser.EmailAdress}\n" +
                      $"Data de nascimento {currentUser.DateOfBirth}\n" +
                      $"Gênero : {currentUser.Gender}\n" +
                      $"Celular : {currentUser.MobilePhone}");
        }

        private UsuarioEscola GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity is not null)
            {
                var userClaims = identity.Claims;

                return new UsuarioEscola
                {
                    Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                    Name = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                    Surname = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                    EmailAdress = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                    DateOfBirth = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.DateOfBirth)?.Value,
                    Gender = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Gender)?.Value,
                    MobilePhone = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.MobilePhone)?.Value,
                    Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value,
                };
            }
            return null;
        }
    }
}
