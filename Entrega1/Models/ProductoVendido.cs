using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Entrega1.Models
{
    public class ProductoVendido
    {
        public long Id { get; set; }
        public long IdProducto { get; set; }
        public int Stock { get; set; }
        public long IdVenta { get; set; }

        public List<ProductoVendido> productoVendido { get; set; }

        public ProductoVendido()
        {
            productoVendido = new List<ProductoVendido>();
        }

        public List<ProductoVendido> ListarProductoVendido()
        {
            string connectionString = @"Server=DESKTOP-S8R6BIK\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;TrustServerCertificate=true";
            var query = "SELECT Id, IdProducto, Stock, IdVenta FROM ProductoVendido";
            var listaProductoVendido = new List<ProductoVendido>();
            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var productovendido = new ProductoVendido();
                            productovendido.Id = dr.GetInt64("Id");
                            productovendido.IdProducto = dr.GetInt64("IdProducto");
                            productovendido.Stock = dr.GetInt32("Stock");
                            productovendido.IdVenta = dr.GetInt64("IdVenta");
                            listaProductoVendido.Add(productovendido);
                        }
                    }
                }
            }
            return listaProductoVendido;
        }
    }
}
