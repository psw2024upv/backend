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

        public IList<CarritoCompra> ObtenerChart()
        {
            var productosTask = interf.GetChart(); // Obtiene la tarea para obtener todos los productos
            productosTask.Wait(); // Espera a que la tarea se complete
            //return productosTask.Result;
            List<CarritoCompra> productos1 = productosTask.Result;
            return productos1;
        }

        public IList<Articulo> ObtenerArticulos()
        {
            var productosTask = interf.GetAllArticles(); // Obtiene la tarea para obtener todos los productos
            productosTask.Wait(); // Espera a que la tarea se complete
            //return productosTask.Result;
            List<Articulo> productos1 = productosTask.Result;
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

            
            allContents = allContents.Where(c => c.Precio_cents==keyWords).ToList();
            

            return allContents.ToList();
        }

        public IList<Articulo> GetArticlesByName(string keyWords)
        {
            

            IList<Articulo> allContents = ObtenerArticulos();

            
            allContents = allContents.Where(c => c.Nombre==keyWords).ToList();
            

            return allContents.ToList();
        }

        public IList<CarritoCompra> GetChartByUser(Usuario user)
        {
            

            IList<CarritoCompra> allContents = ObtenerChart();

            
            allContents = allContents.Where(c => c.Id_usuario==user.Id).ToList();
            

            return allContents.ToList();
        }

        public IList<Producto> GetProductByChart(CarritoCompra carr)
        {
            

            IList<Producto> allContents = ObtenerProductos();

            
            allContents = allContents.Where(c => c.Id==carr.Id_producto).ToList();
            

            return allContents.ToList();
        }

        public IList<Articulo> GetArticleByProduct(Producto prod)
        {
            

            IList<Articulo> allContents = ObtenerArticulos();

            
            allContents = allContents.Where(c => c.Id==prod.Id_articulo).ToList();
            

            return allContents.ToList();
        }

        public void AddMember(Usuario user)
        {

            
            IList<Usuario> allUsers = ObtenerUsuarios();


            bool nicknamebool = allUsers.Any(u => u.Nick_name == user.Nick_name);

            // Verificar si ya existe un miembro con el mismo correo electrónico
            bool emailbool = allUsers.Any(u => u.Email == user.Email);


            if (!nicknamebool && !emailbool)
            {
                interf.InsertarUser(user);
            }
            else
            {
                if (nicknamebool)
                    throw new Exception("El member con nick " + user.Nick_name + " ya existe.");

                if (emailbool)
                    throw new Exception("El member con correo electrónico " + user.Email + " ya existe.");
            }

        }

        public async void Login(String nick, String password)
        {
            if(nick == "" || password == "" ) throw new Exception("Existen campos vacíos");

            if (await interf.UsuarioExistePorApodo(nick)==false) throw new Exception("El usuario no existe");
            Usuario user =  await interf.UserByNick(nick);
            
            if (!user.Contraseña.Equals(password)) throw new Exception("Contraseña incorrecta");
            userlogin = user;
            Console.WriteLine("Usuario con nick :" + user.Nick_name + "y contraseña :" + user.Contraseña + " logueado");
        }

        public Usuario UserLogged()
        {
            Usuario user = userlogin;
            return user;
        }

        public void Logout()
        {
            if(userlogin == null) throw new Exception("Usuario no loggeado");
            userlogin = null;
            DateTime fechaacceso = DateTime.Now;
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
                Id_usuario = usuarioId,
                Id_producto = productoId
                // Puedes añadir otros campos si los necesitas, como cantidad, fecha, etc.
            };

            interf.InsertarCarrito(nuevoElemento);
            
        }


        // Método fábrica para crear usuarios
        public void CrearUsuario(string nombre, string nick_name, string contraseña, string email, int edad, int? limiteGasto = null)
        {
            Usuario nuevoUsuario;

            if (limiteGasto != null)
            {
                // Crear un nuevo Comprador
                nuevoUsuario = new Comprador
                {
                    Nombre = nombre,
                    Nick_name = nick_name,
                    Contraseña = contraseña,
                    Email = email,
                    Edad = edad,
                    Limite_gasto_cents_mes = limiteGasto.Value
                };
            }
            else
            {
                // Crear un nuevo Usuario
                nuevoUsuario = new Usuario
                {
                    Nombre = nombre,
                    Nick_name = nick_name,
                    Contraseña = contraseña,
                    Email = email,
                    Edad = edad
                };
            }
            AgregarUsuarioABaseDeDatos(nuevoUsuario,limiteGasto);

            // Retornar el nuevo usuario creado
        }

        // Método para agregar usuario a la base de datos
        public void AgregarUsuarioABaseDeDatos(Usuario usuario,int? limiteGasto)
        {


            // Aquí debes llamar a los métodos de tu capa de persistencia para insertar el usuario en la base de datos
            Usuario usuario2;
            if (usuario is Comprador)
            {
                // Si el usuario es un Comprador, insertamos primero el Usuario y luego el Comprador

                // Insertar el Usuario en la tabla de Usuarios
                usuario2 = new Usuario{
                    Nombre = usuario.Nombre,
                    Nick_name = usuario.Nick_name,
                    Contraseña = usuario.Contraseña,
                    Email = usuario.Email,
                    Edad = usuario.Edad
                };
                try
                {
                    AddMember(usuario2);
                }
                catch (Exception ex)
                {
                    // Manejar la excepción, registrarla, imprimir información de depuración, etc.
                    Console.WriteLine("Error al insertar usuario en la base de datos: " + ex.Message);
                }

                // Obtener el ID del Usuario recién insertado
                int usuarioId = usuario2.Id;

                // Insertar el Comprador en la tabla de Compradores
                interf.InsertarBuyer(new Comprador
                {
                    Id = usuarioId, // Utilizar el mismo ID del Usuario
                    Limite_gasto_cents_mes = ((Comprador)usuario).Limite_gasto_cents_mes
                    // Otros atributos específicos de Comprador
                });

            }
            else
            {
                // Si es un usuario normal, lo insertamos directamente en la tabla de Usuarios
                AddMember(usuario);

            }
        }
/*
        // Método fábrica para crear usuarios
        public void CrearUsuario2(string nombre, string nick_name, string contraseña, string email, int edad, int? limiteGasto = null)
        {
            Usuario nuevoUsuario;
            Comprador nuevousuario2;

            // Crear un nuevo Usuario
                nuevoUsuario = new Usuario
                {
                    Nombre = nombre,
                    Nick_name = nick_name,
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
                Limite_gasto_cents_mes = ((Comprador)usuario).Limite_gasto_cents_mes
                // Otros atributos específicos de Comprador
            });

            }

        

*/

    }

}