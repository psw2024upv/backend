using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("productopedido")]
    public class ProductoPedido : BaseModel
    {
        [Column("id_pedido")]
        public int Id_pedido { get; set; }

        [Column("id_producto")]
        public int Id_producto { get; set; }

        // Propiedad de navegación hacia el Pedido
        public Pedido Pedido { get; set; }

        // Propiedad de navegación hacia el Producto
        public Producto Producto { get; set; }

        // Clave primaria compuesta
        [PrimaryKey]
        public (int, int) CompositeKey { get; set; }
    }
}
