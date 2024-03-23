using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Supabase;
using Supabase.Interfaces;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;
using webapi.Models;
using Postgrest.Models;

namespace webapi.Services
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
                .Select(x => new object[] { x.Id, x.Nombre, x.Precio })
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

        public async Task<List<Producto>> GetAllProducts()
        {
            var productos = await _supabaseClient
                                .From<Producto>()
                                .Get();

            List <Producto> productos1 = productos.Models;
            return productos1;
        }



        
    }
}
