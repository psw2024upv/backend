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

        
        // Otros campos que puedas necesitar


        // Relación con Cliente si es necesario

    }
}