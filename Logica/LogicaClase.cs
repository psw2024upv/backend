using backend.Services;
using backend.Models;
using System.Collections.Generic;

namespace backend.Logica
{
    public class LogicaClase : InterfazLogica
    {
        private readonly Interfaz interf;
        private Usuario userlogin;
        public LogicaClase(Interfaz interf)
        {
            this.interf = interf;
        }


        public IList<Producto> ObtenerProductos()
        {
            var productosTask = interf.GetAllProducts(); // Obtiene la tarea para obtener todos los productos
            productosTask.Wait(); // Espera a que la tarea se complete
            //return productosTask.Result;
            List<Producto> productos1 = productosTask.Result;
            return productos1;
        }

        public IList<Usuario> ObtenerUsuarios()
        {
            var productosTask = interf.GetAllUsers(); // Obtiene la tarea para obtener todos los productos
            productosTask.Wait(); // Espera a que la tarea se complete
            //return productosTask.Result;
            List<Usuario> productos1 = productosTask.Result;
            return productos1;
        }

        public List<Usuario> ObtenerUsuarios2()
        {
            var productosTask = interf.GetAllUsers(); // Obtiene la tarea para obtener todos los productos
            productosTask.Wait(); // Espera a que la tarea se complete
            //return productosTask.Result;
            List<Usuario> productos1 = productosTask.Result;
            return productos1;
        }

        public Boolean Bool1(string nick)
        {
            var bool2 = interf.UsuarioExistePorApodo(nick);
            bool2.Wait();
            Boolean bool3 = bool2.Result;
            return bool3;

        }


        public IList<Producto> GetContentsByParameters2(int keyWords)
        {
            

            IList<Producto> allContents = ObtenerProductos();

            
            allContents = allContents.Where(c => c.PrecioCents==keyWords).ToList();
            

            return allContents.ToList();
        }

        public void AddMember(Usuario user)
        {

            
            IList<Usuario> allUsers = ObtenerUsuarios();


            bool nicknamebool = allUsers.Any(u => u.NickName == user.NickName);

            // Verificar si ya existe un miembro con el mismo correo electrónico
            bool emailbool = allUsers.Any(u => u.Email == user.Email);


            if (!nicknamebool && !emailbool)
            {
                interf.InsertarUser(user);
            }
            else
            {
                if (nicknamebool)
                    throw new Exception("El member con nick " + user.NickName + " ya existe.");

                if (emailbool)
                    throw new Exception("El member con correo electrónico " + user.Email + " ya existe.");
            }

        }

        public async void Login(String nick, String password)
        {
            if(nick == "" || password == "" ) throw new Exception("Existen campos vacíos");

            if ( await interf.UsuarioExistePorApodo(nick)==false) throw new Exception("El usuario no existe");
            Usuario user =  await interf.UserByNick(nick);
            
            if (!user.Contraseña.Equals(password)) throw new Exception("Contraseña incorrecta");
            userlogin = user;
            Console.WriteLine("Usuario con nick :" + user.NickName + "y contraseña :" + user.Contraseña + "logueado");
        }

        public Usuario UserLogged()
        {
            Usuario user = userlogin;
            return user;
        }


        public  Usuario ObtenerUsuarioPorNick(string nick)
        {

            var productosTask = interf.UserByNick(nick); // Obtiene la tarea para obtener todos los productos
            productosTask.Wait(); // Espera a que la tarea se complete
            //return productosTask.Result;
            Usuario user1 = productosTask.Result;
            return user1;
        }

        public  Producto ObtenerProductoPorPrecio(int nick)
        {

            var productosTask = interf.ProductByPrice(nick); // Obtiene la tarea para obtener todos los productos
            productosTask.Wait(); // Espera a que la tarea se complete
            //return productosTask.Result;
            Producto user1 = productosTask.Result;
            return user1;
        }
        public  Comprador ObtenerCompradorPorNick(string nick)
        {

            var productosTask = interf.BuyerByNick(nick); // Obtiene la tarea para obtener todos los productos
            productosTask.Wait(); // Espera a que la tarea se complete
            //return productosTask.Result;
            Comprador user1 = productosTask.Result;
            return user1;
        }

        public  Usuario ObtenerUsuarioPorEdad(int edad)
        {

            var productosTask = interf.UserByAge(edad); // Obtiene la tarea para obtener todos los productos
            productosTask.Wait(); // Espera a que la tarea se complete
            //return productosTask.Result;
            Usuario user1 = productosTask.Result;
            return user1;
        }

        public Usuario UpdateEdadUsuario(Usuario usuario,int edad)
        {
            var usuario1 = interf.UpdateAgeUser(usuario,usuario.Edad,edad);
            usuario1.Wait();
            Usuario user1 = usuario1.Result;
            
            return user1;

        }

        public void AddUsuario(Usuario usuario)
        {
            interf.InsertarUser(usuario);

        }

        public void AgregarAlCarrito(int usuarioId, int productoId)
        {
            // Aquí iría la lógica para insertar el nuevo elemento en la tabla CarritoCompra
            // Por ejemplo:
            CarritoCompra nuevoElemento = new CarritoCompra
            {
                IdUsuario = usuarioId,
                IdProducto = productoId
                // Puedes añadir otros campos si los necesitas, como cantidad, fecha, etc.
            };

            interf.InsertarCarrito(nuevoElemento);
            
        }


        // Método fábrica para crear usuarios
        public void CrearUsuario(string nombre, string NickName, string contraseña, string email, int edad, int? limiteGasto = null)
        {
            Usuario nuevoUsuario;

            if (limiteGasto != null)
            {
                // Crear un nuevo Comprador
                nuevoUsuario = new Comprador
                {
                    Nombre = nombre,
                    NickName = NickName,
                    Contraseña = contraseña,
                    Email = email,
                    Edad = edad,
                    LimiteGastoCentsMes = limiteGasto.Value
                };
            }
            else
            {
                // Crear un nuevo Usuario
                nuevoUsuario = new Usuario
                {
                    Nombre = nombre,
                    NickName = NickName,
                    Contraseña = contraseña,
                    Email = email,
                    Edad = edad
                };
            }
            AgregarUsuarioABaseDeDatos(nuevoUsuario,limiteGasto);

            // Retornar el nuevo usuario creado
        }

        // Método para agregar usuario a la base de datos
        public void SeleccionarProductoYAgregarAlCarrito(string nombreProducto, int idUsuario)
        {
            IList<Producto> productos = ObtenerProductosPorNombre(nombreProducto);

            if (productos.Count == 0)
            {
                throw new Exception("No se encontraron productos con el nombre especificado.");
            }
            else if (productos.Count > 1)
            {
                throw new Exception("Se encontraron múltiples productos con el mismo nombre. Especifique un nombre más específico.");
            }
            else
            {
                // Obtener el único producto encontrado
                Producto producto = productos[0];

                // Crear un nuevo elemento de CarritoCompra
                CarritoCompra nuevoElemento = new CarritoCompra
                {
                    IdUsuario = idUsuario,
                    IdProducto = producto.Id,
                    Comprador = new Comprador { Id = idUsuario },
                    Producto = producto
                };

                // Insertar el nuevo elemento de CarritoCompra en la base de datos
                interf.InsertarCarrito(nuevoElemento);
            }
        }



        public IList<Producto> ObtenerProductosPorNombre(string nombre)
        {
            var productosTask = interf.GetAllProducts(); // Obtiene la tarea para obtener todos los productos
            productosTask.Wait(); // Espera a que la tarea se complete
            List<Producto> productos = productosTask.Result;
            
            // Filtrar los productos por nombre
            var productosFiltrados = productos.Where(p => p.Articulo.Nombre.Contains(nombre)).ToList();
            
            return productosFiltrados;
        }

        // public void SeleccionarProductoYAgregarAlCarrito(string nombreProducto, int idUsuario)
        // {
        //     // Obtener el producto por su nombre
        //     IList<Producto> productos = ObtenerProductosPorNombre(nombreProducto);

        //     if (productos.Count == 0)
        //     {
        //         // Manejar el caso en el que no se encuentra ningún producto con el nombre dado
        //         throw new Exception("No se encontraron productos con el nombre especificado.");
        //     }
        //     else if (productos.Count > 1)
        //     {
        //         // Manejar el caso en el que se encuentran múltiples productos con el mismo nombre
        //         throw new Exception("Se encontraron múltiples productos con el mismo nombre. Especifique un nombre más específico.");
        //     }
        //     else
        //     {
        //         // Obtener el único producto encontrado
        //         Producto producto = productos[0];

        //         // Agregar el producto al carrito
        //         AgregarAlCarrito(idUsuario, producto.Id);
        //     }
        // }

/*
        // Método fábrica para crear usuarios
        public void CrearUsuario2(string nombre, string NickName, string contraseña, string email, int edad, int? limiteGasto = null)
        {
            Usuario nuevoUsuario;
            Comprador nuevousuario2;

            // Crear un nuevo Usuario
                nuevoUsuario = new Usuario
                {
                    Nombre = nombre,
                    NickName = NickName,
                    Contraseña = contraseña,
                    Email = email,
                    Edad = edad
                };

            if (limiteGasto == null)
            {

                
                AgregarUsuarioABaseDeDatos(nuevoUsuario);
                
            }
            else
            {
                
                AgregarUsuarioABaseDeDatos(nuevoUsuario);

                
                AgregarUsuarioABaseDeDatos2(nuevoUsuario,limiteGasto);

            }
        }

        // Método para agregar usuario a la base de datos
        public void AgregarUsuarioABaseDeDatos2(Usuario usuario, int? limiteGasto)
        {

            
            // Obtener el ID del Usuario recién insertado
            int usuarioId = usuario.Id;

            // Insertar el Comprador en la tabla de Compradores
            interf.InsertarBuyer(new Comprador
            {
                Id = usuarioId, // Utilizar el mismo ID del Usuario
                LimiteGastoCentsMes = ((Comprador)usuario).LimiteGastoCentsMes
                // Otros atributos específicos de Comprador
            });

            }

        

*/

    }

}