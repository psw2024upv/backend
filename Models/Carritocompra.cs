using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("carritocompra")]
    public class CarritoCompra : BaseModel
    {


        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        [Column("id_producto")]
        public int Id_producto { get; set; }

        
        // Otros campos que puedas necesitar


        // Relación con Cliente si es necesario

    }
}