using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("imagenproducto")]
    public class ImagenProducto : BaseModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("hash")]
        public string Hash { get; set; }

        [Column("url")]
        public string Url { get; set; }

        [Column("id_articulo")]
        public int Id_articulo { get; set; }

        // Propiedad de navegación hacia el Articulo
        public Articulo Articulo { get; set; }
    }
}
