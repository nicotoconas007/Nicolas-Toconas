using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace Entrega1.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public Usuario()
        {
            Usuarios = new List<Usuario>();
        }

        public List<Usuario> ListarUsuarios()
        {
            string connectionString = @"Server=DESKTOP-S8R6BIK\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;TrustServerCertificate=true";
            var query = "SELECT Id,Nombre,Apellido,NombreUsuario,Contraseña,Mail FROM Usuario";
            var listaUsuarios = new List<Usuario>();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            var usuario = new Usuario();
                            usuario.Id = dr.GetInt64("Id");
                            usuario.Nombre = dr.GetString("Nombre");
                            usuario.Apellido = dr.GetString("Apellido");
                            usuario.NombreUsuario = dr.GetString("NombreUsuario");
                            usuario.Contraseña = dr.GetString("Contraseña");
                            usuario.Mail = dr.GetString("Mail");
                            listaUsuarios.Add(usuario);
                        }

                    }

                }
            }
            return listaUsuarios;

        }

        public static Usuario IniciarSesion(string nombreUsuario, string contrasena)

        {
            string connectionString = @"Server=DESKTOP-S8R6BIK\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;TrustServerCertificate=true";
            using (var connection = new SqlConnection(connectionString))

            {
                connection.Open();
                const string query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contrasena";
                using (var command = new SqlCommand(query, connection))

                {
                    command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@contrasena", contrasena);
                    using (var reader = command.ExecuteReader())

                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = reader.GetInt64(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                NombreUsuario = reader.GetString(3),
                                Contraseña = reader.GetString(4),
                                Mail = reader.GetString(5)
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}

