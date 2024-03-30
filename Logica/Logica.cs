using backend.Services;
using backend.Models;

namespace backend.Logica
{
    public class Logica
    {
        private readonly Interfaz interf;
        private Usuario userlogin;
        public Logica(Interfaz interf)
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


        public IList<Producto> GetContentsByParameters2(string keyWords, string creatorNick, string subject, DateTime earliest, DateTime latest)
        {
            

            IList<Producto> allContents = ObtenerProductos();

            if (!string.IsNullOrEmpty(keyWords))
            {
                allContents = allContents.Where(c => c.Nombre.Contains(keyWords)).ToList();
            }

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

            if ( await interf.UsuarioExistePorApodo(nick)==false) throw new Exception("El usuario no existe");
            Usuario user =  await interf.UserByNick(nick);
            
            if (!user.Contraseña.Equals(password)) throw new Exception("Contraseña incorrecta");
            userlogin = user;
        }

        public Usuario UserLogged()
        {
            Usuario user = userlogin;
            return user;
        }

        
        /*
        public void AddProduct(Producto producto)
        {
            
            // Restricción: No puede haber dos asignaturas con el mismo code
            if (interf.GetProductsById(producto.Id) == null)
            {
                // Restricción: No puede haber dos asignaturas con el mismo name
                if (interf.GetAllProducts(x => x.Name == producto.Nombre).Any())
                {
                    // Sólo se salva si no hay Code ni email duplicado
                    interf.InsertarProducto(producto);
                }
                else
                    throw new ServiceException("Subject with name " + producto.Nombre + " already exists.");
            }
            else
                throw new ServiceException("Subject with code " + producto.Precio + " already exists.");
        }
*/

    }

}