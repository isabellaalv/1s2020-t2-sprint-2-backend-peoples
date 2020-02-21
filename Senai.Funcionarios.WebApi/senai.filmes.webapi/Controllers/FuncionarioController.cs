﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;

namespace senai.Filmes.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos generos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _generoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        /// dominio/api/Generos
        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            // Faz a chamada para o método .Listar();
            return _funcionarioRepository.Listar();
        }

        [HttpPost]
        public FuncionarioDomain Post(FuncionarioDomain Funcionario)
        {
            return _funcionarioRepository.Cadastrar(Funcionario);
        }

        [HttpPut("IdFuncionario}")]
        public FuncionarioDomain Put(int IdFuncionario, FuncionarioDomain Funcionario)
        {
            return _funcionarioRepository.Atualizar(IdFuncionario, Funcionario);
        }

        [HttpDelete("IdFuncionario}")]
        public FuncionarioDomain Deletar(int IdFuncionario, FuncionarioDomain Funcionario)
        {
            return _funcionarioRepository.Deletar(IdFuncionario, Funcionario);
        }

    }

}