using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requesição será no formato domínio/api/NomeController
    [Route("api/")]

    //Define que é um controlador de API
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly string issuer;


        //Cria um objeto _usuarioRepository que ira receber todos os métodos definidos na interface
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IEnumerable<UsuarioDomain> Get()
        {
            return _usuarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar (UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.Cadastrar(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("peoples-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Peoples.WebApi",
                audience: "Filmes.WebApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }
    }
}
