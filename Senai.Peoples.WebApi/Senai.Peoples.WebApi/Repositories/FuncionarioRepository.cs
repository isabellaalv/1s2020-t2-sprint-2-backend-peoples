using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private string StringConexao = "Data Source=DEV16\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132;";

        public List<FuncionarioDomain> Listar()
        {

            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT * FROM Funcionarios;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0])
                            ,

                            Nome = rdr["Nome"].ToString()

                            ,

                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public FuncionarioDomain Cadastrar(FuncionarioDomain Funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"INSERT INTO Funcionarios (Nome, Sobrenome) VALUES('{Funcionario.Nome}' , '{Funcionario.Sobrenome}') ; ";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
                return Funcionario;

            }
        }

        public FuncionarioDomain Atualizar(int IdFuncionario, FuncionarioDomain Funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"UPDATE Funcionarios SET Nome = '{Funcionario.Nome}', Sobrenome = '{Funcionario.Sobrenome}' WHERE IdFuncionario = {IdFuncionario}; ";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
                return Funcionario;
            }
        }

       public void Deletar(int IdFuncionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"DELETE FROM Funcionarios WHERE IdFuncionario = {IdFuncionario}; ";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}

