using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();
        FuncionarioDomain Cadastrar(FuncionarioDomain Funcionario);
        FuncionarioDomain Atualizar(int IdFuncionario, FuncionarioDomain Funcionario);
        void Deletar(int IdFuncionario);
        List<FuncionarioDomain> BuscarPorNome(string Nome);
    }
}
