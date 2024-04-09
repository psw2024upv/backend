using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("alertas")]
    public class Alerta : BaseModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("texto")]
        public string Texto { get; set; }

        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        // Propiedad de navegación hacia el Usuario
        public Usuario Usuario { get; set; }
    }
}
