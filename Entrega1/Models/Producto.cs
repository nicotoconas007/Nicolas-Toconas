using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Entrega1.Models
{
    public class Producto
    {
        public long Id { get; set; }
        public string Descripciones { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public long IdUsuario { get; set; }

        public List<Producto> Productos { get; set; }

        public Producto()
        {
            Productos = new List<Producto>();
        }

        public List<Producto> ListarProductos()
        {

            string connectionString = @"Server=DESKTOP-S8R6BIK\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;TrustServerCertificate=true";
            var query = "SELECT Id,Descripciones,Costo,PrecioVenta,Stock,IdUsuario FROM Producto";
            var listaProductos = new List<Producto>();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            var producto = new Producto();
                            producto.Id = dr.GetInt64("Id");
                            producto.Descripciones = dr.GetString("Descripciones");
                            producto.Costo = dr.GetDecimal("Costo");
                            producto.PrecioVenta = dr.GetDecimal("PrecioVenta");
                            producto.Stock = dr.GetInt32("Stock");
                            producto.IdUsuario = dr.GetInt64("IdUsuario");
                            listaProductos.Add(producto);
                        }

                    }

                }
            }
            return listaProductos;
        }
    }
}
