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


        public List<Producto> ObtenerProductos()
        {
            var productosTask = interf.GetAllProducts(); // Obtiene la tarea para obtener todos los productos
            productosTask.Wait(); // Espera a que la tarea se complete
            return productosTask.Result;

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