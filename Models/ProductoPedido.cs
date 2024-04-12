using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class ProductoPedido
    {
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }

        [ForeignKey("IdPedido")]
        public Pedido Pedido { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
    }
}
