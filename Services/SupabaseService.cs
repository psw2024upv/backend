using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Supabase;
using Supabase.Interfaces;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;
using backend.Models;
using Postgrest.Models;

namespace backend.Services
{
    public class SupabaseService : Interfaz
    {
        private readonly Supabase.Client _supabaseClient;

        public SupabaseService(IConfiguration configuration)
        {
            var supabaseUrl = configuration["Supabase:Url"];
            var supabaseKey = configuration["Supabase:ApiKey"];

            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            _supabaseClient = new Supabase.Client(supabaseUrl, supabaseKey, options);

             // Espera a que la inicialización se complete antes de devolver el control
        }

        public async Task InitializeSupabaseAsync()
        {
            Console.WriteLine("Iniciando la conexión a Supabase...");
            await _supabaseClient.InitializeAsync();
            Console.WriteLine("Conexión a Supabase completada.");
        }
        
        public async Task InsertarProducto(Producto nuevoProducto)
        {
            

            // Inserta el nuevo producto en la tabla correspondiente
            await _supabaseClient
                .From<Producto>()
                .Insert(nuevoProducto);
            Console.WriteLine("Producto insertado correctamente en Supabase.");
        }

        public async Task<List<Producto>> GetProductsById(int y)
        {
            var result = await _supabaseClient
                .From<Producto>()
                .Where(x => x.Id == y)
                .Get();
            List <Producto> productos = result.Models;
            return productos;
        }

        public async Task EliminarProducto(Producto producto)
        {
            await _supabaseClient
                .From<Producto>()
                .Delete(producto);
        }

        public async Task<Producto> ProductByPrice(int filtro)
        {
            var result = await _supabaseClient
                                .From<Producto>()
                                .Where(x => x.Precio_cents == filtro)
                                .Get();
            
                                
            Producto users = result.Model;
            return users;                    
        }

        public async Task<List<Producto>> GetAllProducts()
        {
            var productos = await _supabaseClient
                                .From<Producto>()
                                .Get();

            List <Producto> productos1 = productos.Models;
            return productos1;
        }

        public async Task<List<Usuario>> GetAllUsers()
        {
            var users = await _supabaseClient
                                .From<Usuario>()
                                .Get();

            List <Usuario> allusers = users.Models;
            return allusers;
        
        }

        public async Task<Usuario> UserByNick(string filtro)
        {
            var result = await _supabaseClient
                                .From<Usuario>()
                                .Where(x => x.Nick_name == filtro)
                                .Get();
            
                                
            Usuario users = result.Model;
            return users;                    
        }

        public async Task<List<Comprador>> GetAllBuyers()
        {
            var users = await _supabaseClient
                                .From<Comprador>()
                                .Get();

            List <Comprador> allusers = users.Models;
            return allusers;
        
        }

        

        public async Task<Comprador> BuyerByNick(string filtro)
        {
            var result = await _supabaseClient
                                .From<Comprador>()
                                .Select("*,usuario:nick_name")
                                .Where(x => x.Nick_name == filtro)
                                .Get();
            
                                
            Comprador users = result.Model;
            return users;                    
        }

        public async Task<Usuario> UserByAge(int filtro)
        {
            var result = await _supabaseClient
                                .From<Usuario>()
                                .Where(x => x.Edad == filtro)
                                .Get();
            
                                
            Usuario users = result.Model;
            return users;                    
        }

        public async Task InsertarUser(Usuario nuevouser)
        {
            

            // Inserta el nuevo producto en la tabla correspondiente
            await _supabaseClient
                    .From<Usuario>()
                    .Insert(nuevouser);
            Console.WriteLine("User insertado correctamente en Supabase.");
        }

        public async Task<bool> UsuarioExistePorApodo(string apodo)
        {
        // Realizar una consulta a la tabla de usuarios para verificar si existe un usuario con el apodo dado
            var result = await _supabaseClient
                                .From<Usuario>()
                                .Where(x => x.Nick_name == apodo)
                                .Get();

            // Si la consulta devuelve algún resultado, significa que el usuario existe
            return result.Models.Any();
        }

        public async Task<Usuario> UpdateAgeUser(Usuario usuario,int edad1 ,int edad)
        {
            await _supabaseClient
                    .From<Usuario>()
                    .Where(x => x.Edad == edad1)
                    .Set(x => x.Edad, edad)
                    .Update();

            return usuario;
        }

        public async Task InsertarCarrito(CarritoCompra nuevocarrito)
        {
            

            // Inserta el nuevo producto en la tabla correspondiente
            await _supabaseClient
                    .From<CarritoCompra>()
                    .Insert(nuevocarrito);
            Console.WriteLine("Carrito insertado correctamente en Supabase.");
        }
        
    }
}
