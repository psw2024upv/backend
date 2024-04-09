using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("contacto")]
    public class Contacto : BaseModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("fecha_cumpleaños")]
        public DateTime Fecha_cumpleaños { get; set; }

        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        // Propiedad de navegación hacia el Comprador
        public Comprador Comprador { get; set; }
    }
}
