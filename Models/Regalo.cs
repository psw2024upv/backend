using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("regalo")]
    public class Regalo : BaseModel
    {
        [Column("id_contacto")]
        public int Id_contacto { get; set; }

        [Column("id_producto")]
        public int Id_producto { get; set; }

        // Propiedad de navegación hacia el Contacto
        public Contacto Contacto { get; set; }

        // Propiedad de navegación hacia el Producto
        public Producto Producto { get; set; }

        // Clave primaria compuesta
        [PrimaryKey]
        public (int, int) CompositeKey { get; set; }
    }
}
