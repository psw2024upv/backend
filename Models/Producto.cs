using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("producto")]
    public class Producto : BaseModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("precio_cents")]
        public int Precio_cents { get; set; }

        [Column("unidades")]
        public int Unidades { get; set; }

        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        [Column("id_articulo")]
        public int Id_articulo { get; set; }

        // Propiedad de navegación hacia el Vendedor
        public Vendedor Vendedor { get; set; }

        // Propiedad de navegación hacia el Articulo
        public Articulo Articulo { get; set; }
    }
}
