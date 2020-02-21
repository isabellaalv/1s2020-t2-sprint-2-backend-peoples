using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{

    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class FuncionarioController : ControllerBase
    {

        private IFuncionarioRepository _funcionarioRepository { get; set; }


        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        }

        [HttpPost]
        public FuncionarioDomain Post(FuncionarioDomain Funcionario)
        {
            return _funcionarioRepository.Cadastrar(Funcionario);
        }

        [HttpPut("{IdFuncionario}")]
        public FuncionarioDomain Put(int IdFuncionario, FuncionarioDomain Funcionario)
        {
            return _funcionarioRepository.Atualizar(IdFuncionario, Funcionario);
        }

        [HttpDelete("{IdFuncionario}")]
        public IActionResult Deletar(int IdFuncionario)
        {
            _funcionarioRepository.Deletar(IdFuncionario);

            return Ok();
        }
    }
}
