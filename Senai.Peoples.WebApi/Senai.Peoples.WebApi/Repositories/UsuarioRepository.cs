using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string StringConexao = "Data Source=DEV16\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132;";
        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> usuarios = new List<UsuarioDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT * FROM Usuario;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr[0])

                            ,

                            Email = rdr["Email"].ToString()

                            ,

                            Senha = rdr["Senha"].ToString()

                            ,

                            IdTipoUsuario = Convert.ToInt32(rdr[0])

                        };

                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }

        public UsuarioDomain Cadastrar(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"SELECT IdUsuario, Email, Senha, IdTipoUsuario FROM Usuario WHERE Email = '{Email}' AND Senha = '{Senha}';";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery
                }

            }
        }
    }
}
