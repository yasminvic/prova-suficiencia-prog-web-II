using Domain.DTO;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _userService;

        public AuthController(IUsuarioService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO user)
        {
            UsuarioDTO found = await _userService.GetByEmail(user.email);

            if (found == null)
            {
                return BadRequest("Login errado! Email ou Senha incorretos");
            }

            if (!found.ValidaSenha(user.senha))
            {
                return BadRequest("Login errado! Email ou Senha incorretos");
            }


            var token = CriarToken();
            return Ok(new { token });
        }

        private string CriarToken()
        {
            const string SECRET_KEY = "9fbbdd98-f2f4-4673-b48e-083ec1be44dc";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yasminvic",
                audience: "api",
                expires: DateTime.Now.AddMonths(1),
                signingCredentials: credencial
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}