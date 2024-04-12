using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Regalo
    {
        public int IdContacto { get; set; }
        public int IdProducto { get; set; }

        [ForeignKey("IdContacto")]
        public Contacto Contacto { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
    }
}
