using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("carritocompra")]
    public class CarritoCompra : BaseModel
    {

        [PrimaryKey]
        [Column("id_usuario")]
        public int Id_usuario { get; set; }
        
        [PrimaryKey]
        [Column("id_producto")]
        public int Id_producto { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("IdUsuario")]
        public Comprador Comprador { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
    }
} 