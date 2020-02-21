using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Repositories
{
    /// <summary>
    /// Repositório dos gêneros
    /// </summary>
    public class FuncionarioRepository : IFuncionarioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source - Nome do Servidor
        /// initial catalog - Nome do Banco de Dados
        /// integrated security=true - Faz a autenticação com o usuário do sistema
        /// user Id=sa; pwd=sa@132 - Faz a autenticação com um usuário específico, passando o logon e a senha
        /// </summary>
        private string StringConexao = "Data Source=DEV16\\SQLEXPRESS; initial catalog=Filmes_tarde; user Id=sa; pwd=sa@132;";


        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        public List<FuncionarioDomain> Listar()
        {
            // Cria uma lista funcionarios onde serão armazenados os dados
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "SELECT * FROM Funcionarios;";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para ler, o laço se repete
                    while (rdr.Read())
                    {
                        // Cria um objeto genero do tipo GeneroDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            // Atribui à propriedade IdFuncionario o valor da primeira coluna da tabela do banco
                            IdFuncionario = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Nome = rdr["Nome"].ToString()

                            ,

                            Sobrenome = rdr["Sobrenome"].ToString()


                        };

                        // Adiciona o genero criado à tabela funcionarios
                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de funcionarios
            return funcionarios;
        }

        public FuncionarioDomain Cadastrar(FuncionarioDomain Funcionario)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"INSERT INTO Funcionarios (Nome, Sobrenome) VALUES('{Funcionario.Nome} , {Funcionario.Sobrenome}) ; " ;


                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
                return Funcionario;
            }
        }
        
        public FuncionarioDomain Atualizar(int IdFuncionario , FuncionarioDomain Funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"UPDATE Funcionarios SET Nome = {Funcionario.Nome}, Sobrenome = {Funcionario.Sobrenome} WHERE IdFuncionario = {Funcionario.IdFuncionario};' ";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
                return Funcionario;
            }
        }

        public FuncionarioDomain Deletar(int IdFuncionario, FuncionarioDomain Funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"DELETE FROM Funcionarios WHERE IdFuncionario = {Funcionario.IdFuncionario}; ";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                } 
                return Funcionario;
            }
        }

    }
}
