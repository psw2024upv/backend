using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("producto")]
    public class Producto : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }


        [Column("precio_cents")]
        public int Precio_cents { get; set; }

        [Column("unidades")]
        public int Unidades { get; set; }

        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        [Column("id_articulo")]
        public int Id_articulo { get; set; }
        // Otros campos que puedas necesitar


        // Relación con Cliente si es necesario

    }
}
