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
            // Obtener el usuario logueado
            var user = _logica.UserLogged();

            // Verificar si el usuario está autenticado
            if (user == null)
            {
                // El usuario no está autenticado, puedes devolver un error o redirigir a la página de inicio de sesión
                return Unauthorized();
            }
            var userId = user.Id;
            _logica.AgregarAlCarrito(userId, request.ProductId);
            return Ok();
        }

        [HttpPost("carritomanual")]
        public IActionResult AgregarAlCarritoManual([FromBody] CarritoCompraRequest2 request)
        {
            _logica.AgregarAlCarrito(request.UserId, request.ProductId);
            return Ok();
        }

        [HttpGet("userlogged")]
        public IActionResult ObtenerUsuarioLogueado()
        {
            // Obtener el usuario logueado
            var user = _logica.UserLogged();

            // Verificar si el usuario está autenticado
            if (user == null)
            {
                // El usuario no está autenticado, puedes devolver un error o redirigir a la página de inicio de sesión
                return Unauthorized();
            }

            // Devolver el usuario logueado
            return Ok(user);
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

        [HttpPost("login2")]
        public IActionResult Login2([FromBody] LoginRequest request)
        {
            _logica.Login(request.Nick, request.Password);
            var perfil = _logica.ObtenerUsuarioPorNick(request.Nick);
            var user = _logica.GetChartByUser(perfil);
            var productos = new List<Producto>();
            var items = new List<Articulo>();

            // Para cada carrito en la lista de carritos
            foreach(var product in user)
            {
                // Obtener los artículos asociados al producto
                var productItems = _logica.GetProductByChart(product);
                
                // Agregar los artículos a la lista de items
                productos.AddRange(productItems);
            }
            foreach(var prod in productos)
            {
                // Obtener los artículos asociados al producto
                var productItems = _logica.GetArticleByProduct(prod);
                
                // Agregar los artículos a la lista de items
                items.AddRange(productItems);
            }

            var responseData = new 
            {
                Perfil = perfil,
                ArticulosEnCarrito = items
            };
            return Ok(responseData);
        }

        [HttpPost("registro")]
        public IActionResult RegistrarComprador([FromBody] RegistroRequest request)
        {
            try
            {
                
                if (request.LimiteGasto != null)
                {
                    // El usuario es un comprador
                    _logica.CrearUsuario2(request.Nombre, request.Nick, request.Password, request.Email, request.Edad, request.LimiteGasto.Value);
                }
                else
                {
                    // El usuario es un usuario regular
                    _logica.CrearUsuario2(request.Nombre, request.Nick, request.Password, request.Email, request.Edad);
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


        [HttpPost("registrobuyer")]
        public IActionResult Añadirbuyer(Buyer request)
        {
            
            _logica.AddBuyer2(request.Idd,request.limite);
            return Ok();
        }






        public class CarritoCompraRequest
        {
            public int ProductId { get; set; }
        }
        public class CarritoCompraRequest2
        {
            public int UserId {get; set; }
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
        public class Buyer
        {
            public int Idd { get; set; }
            public int limite { get; set; }
        }

    }
}
