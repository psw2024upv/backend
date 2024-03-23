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
using static System.Runtime.InteropServices.JavaScript.JSType;
using webapi.Models;
using Postgrest.Models;

namespace webapi.Services
{
    public interface Interfaz
    {
        Task InsertarProducto(Producto nuevoProducto);
        Task<List<Producto>> GetProductsById(int y);
        Task EliminarProducto(Producto producto);
        Task<List<Producto>> GetAllProducts();

    }
}