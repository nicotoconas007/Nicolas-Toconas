using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using Entrega1.Models;

//IniciarSesion
Console.WriteLine("Llamado a Iniciar Sesión");
var user = Usuario.IniciarSesion("tcasazza", "SoyTobiasCasazza");
Console.WriteLine($"Usuario: {user.NombreUsuario}, Contraseña: {user.Contraseña}");
Console.WriteLine("");


//ListarUsuarios
Console.WriteLine("Llamado a Listar Usuarios");
Usuario usuario = new Usuario();
List<Usuario> UsersList;
UsersList = usuario.ListarUsuarios();

foreach (var u in UsersList)
{
    Console.WriteLine(u.Id);
    Console.WriteLine(u.Apellido);
    Console.WriteLine(u.Nombre);
}
Console.WriteLine("");


//ListarProductos
Console.WriteLine("Llamado a ListarProductos");
Producto producto = new Producto();
List<Producto> lista;
lista = producto.ListarProductos();

foreach (var p in lista)
{
    Console.WriteLine("Id: " + p.Id);
    Console.WriteLine("Descripcion: " + p.Descripciones);
    Console.WriteLine("Costo: " + p.Costo);
    Console.WriteLine("PrecioVenta: " + p.PrecioVenta);
}
Console.WriteLine("");


//ListarVentas
Console.WriteLine("Llamado a Listar Ventas");
Venta venta = new Venta();
List<Venta> VentasList;
VentasList = venta.ListarVentas();

foreach (var v in VentasList)
{
    Console.WriteLine(v.Id);
    Console.WriteLine(v.Comentarios);
    Console.WriteLine(v.IdUsuario);
}
Console.WriteLine("");

//ListarProductoVendido
Console.WriteLine("Llamado a Listar Producto Vendido");
ProductoVendido productoVendido = new ProductoVendido();
List<ProductoVendido> ProductosVendidosList;
ProductosVendidosList = productoVendido.ListarProductoVendido();

foreach (var pv in ProductosVendidosList)
{
    Console.WriteLine(pv.Id);
    Console.WriteLine(pv.IdProducto);
    Console.WriteLine(pv.Stock);
    Console.WriteLine(pv.IdVenta);
}
Console.WriteLine("");

