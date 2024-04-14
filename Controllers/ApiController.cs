using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Logica;


namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly InterfazLogica _logica;

        public ApiController(InterfazLogica logica)
        {
            this._logica = logica;
        }

        [HttpPost("carrito")]
        public IActionResult AgregarAlCarrito([FromBody] CarritoCompraRequest request)
        {
            _logica.AgregarAlCarrito(request.UserId, request.ProductId);
            return Ok();
        }

        [HttpGet("productos")]
        public IActionResult GetProductos()
        {
            try
            {
            var productos = _logica.ObtenerProductos();
            return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error : " + ex.Message);
            }
        }
    /*
        [HttpGet("buscar/productos")]
        public IActionResult BuscarProductos([FromQuery] string query)
        {
            var productos = _logica.BuscarProductos(query);
            return Ok(productos);
        }
    */
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            _logica.Login(request.Nick, request.Password);
            return Ok();
        }

        [HttpPost("registro")]
        public IActionResult RegistrarComprador([FromBody] RegistroRequest request)
        {
            try
            {
                
                if (request.LimiteGasto != null)
                {
                    // El usuario es un comprador
                    _logica.CrearUsuario(request.Nombre, request.Nick, request.Password, request.Email, request.Edad, request.LimiteGasto.Value);
                }
                else
                {
                    // El usuario es un usuario regular
                    _logica.CrearUsuario(request.Nombre, request.Nick, request.Password, request.Email, request.Edad);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error : " + ex.Message);
            }
        }

        [HttpGet("perfil/{nick}")]
        public IActionResult ObtenerPerfilComprador(string nick)
        {
            var perfil = _logica.ObtenerUsuarioPorNick(nick);
            return Ok(perfil);
        }



        [HttpPost("carrito/agregar")]
        public IActionResult SeleccionarProductoYAgregarAlCarrito([FromBody] SeleccionProductoCarritoRequest request)
        {
            try
            {
                _logica.SeleccionarProductoYAgregarAlCarrito(request.NombreProducto, request.IdUsuario);
                return Ok("Producto agregado al carrito exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpGet("productos/buscar")]
        public IActionResult BuscarProductosPorNombre([FromQuery] string nombre)
        {
            try
            {
                var productos = _logica.ObtenerProductosPorNombre(nombre);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        public class SeleccionProductoCarritoRequest
        {
            public string NombreProducto { get; set; }
            public int IdUsuario { get; set; }
        }



        public class CarritoCompraRequest
        {
            public int UserId { get; set; }
            public int ProductId { get; set; }
        }

        public class LoginRequest
        {
            public string Nick { get; set; }
            public string Password { get; set; }
        }

        public class RegistroRequest
        {
            public string Nombre { get; set; }
            public string Nick { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public int Edad { get; set; }
            public int? LimiteGasto {get; set; }
        }

    }
}
