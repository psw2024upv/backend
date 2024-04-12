using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class CarritoCompra
    {
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }

        [ForeignKey("IdUsuario")]
        public Comprador Comprador { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
    }
}
