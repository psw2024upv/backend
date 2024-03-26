using backend.Services;
using backend.Models;

namespace backend.Logica
{
    public class Logica
    {
        private readonly Interfaz interf;

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


        public IList<Producto> GetContentsByParameters2(string keyWords, string creatorNick, string subject, DateTime earliest, DateTime latest)
        {
            

            IList<Producto> allContents = ObtenerProductos();

            if (!string.IsNullOrEmpty(keyWords))
            {
                allContents = allContents.Where(c => c.Nombre.Contains(keyWords)).ToList();
            }

            return allContents.ToList();
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