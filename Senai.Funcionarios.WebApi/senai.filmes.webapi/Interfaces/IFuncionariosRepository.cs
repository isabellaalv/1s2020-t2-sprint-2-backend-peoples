using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório Genero
    /// </summary>
    interface IFuncionarioRepository
    {
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        List<FuncionarioDomain> Listar();
         FuncionarioDomain Cadastrar(FuncionarioDomain Funcionario);
        FuncionarioDomain Atualizar(int IdFuncionario, FuncionarioDomain Funcionario);
        FuncionarioDomain Deletar(int IdFuncionario, FuncionarioDomain Funcionario);

        


    }
}
