using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Supabase;
using Supabase.Interfaces;
using Microsoft.Extensions.Configuration;
using backend.Services;
using backend.Models;

namespace backend.Logica
{
    public interface InterfazLogica
    {
        IList<Producto> ObtenerProductos();
        IList<Usuario> ObtenerUsuarios();
        List<Usuario> ObtenerUsuarios2();
        Boolean Bool1(string nick);
        IList<Producto> GetContentsByParameters2(int keyWords);
        void AddMember(Usuario user);
        void Login(String nick, String password);
        Usuario UserLogged();
        Usuario ObtenerUsuarioPorNick(string nick);
        Producto ObtenerProductoPorPrecio(int nick);
        Comprador ObtenerCompradorPorNick(string nick);
        Usuario ObtenerUsuarioPorEdad(int edad);
        Usuario UpdateEdadUsuario(Usuario usuario,int edad);
        void AddUsuario(Usuario usuario);
        void AgregarAlCarrito(int usuarioId, int productoId);
        void CrearUsuario(string nombre, string nick_name, string contraseña, string email, int edad, int? limiteGasto = null);
        void AgregarUsuarioABaseDeDatos(Usuario usuario,int? limiteGasto);
        IList<CarritoCompra> GetChartByUser(Usuario user);
        IList<CarritoCompra> ObtenerChart();
        IList<Articulo> ObtenerArticulos();
        IList<Articulo> GetArticleByProduct(Producto prod);
        IList<Producto> GetProductByChart(CarritoCompra carr);
        void Logout();
        IList<Articulo> GetArticlesByName(string keyWords);
        void CrearUsuario2(string nombre, string nick_name, string contraseña, string email, int edad, int? limiteGasto = null);
        void AddBuyer(Comprador comp);
        void AddBuyer2(int idd, int limite);
        IList<Producto> ObtenerProductosPorNombre(string nombre);
        //void AgregarUsuarioABaseDeDatos2(Usuario usuario, int? limiteGasto);
        //void CrearUsuario2(string nombre, string nick_name, string contraseña, string email, int edad, int? limiteGasto = null);

    }
}