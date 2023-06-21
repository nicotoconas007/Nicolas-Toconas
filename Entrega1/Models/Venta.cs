using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Entrega1.Models
{
    public class Venta
    {
        public long Id;
        public string Comentarios;
        public long IdUsuario;
        public List<Venta> Ventas { get; set; }
        public Venta()
        {
            Ventas = new List<Venta>();
        }
        public List<Venta> ListarVentas()
        {
            string connectionString = @"Server=DESKTOP-S8R6BIK\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;TrustServerCertificate=true";
            var query = "SELECT Id,Comentarios,IdUsuario FROM Venta";
            var listaVentas = new List<Venta>();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var venta = new Venta();
                            venta.Id = dr.GetInt64("Id");
                            venta.Comentarios = dr.GetString("Comentarios");
                            venta.IdUsuario = dr.GetInt64("IdUsuario");
                            listaVentas.Add(venta);
                        }
                    }
                }
            }
            return listaVentas;
        }
    }
}
