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
        Usuario CrearUsuario(string nombre, string nick_name, string contraseña, string email, int edad, string limiteGasto = null);
        void AgregarUsuarioABaseDeDatos(Usuario usuario);

    }
}