using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("fotoperfil")]
    public class FotoPerfil : BaseModel
    {
        [Column("hash")]
        public string Hash { get; set; }

        [Column("url")]
        public string Url { get; set; }

        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        // Propiedad de navegación hacia el Usuario
        public Usuario Usuario { get; set; }
    }
}
