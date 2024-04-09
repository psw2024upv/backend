using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("vendedor")]
    public class Vendedor : BaseModel
    {
        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        // Propiedad de navegación hacia el Usuario
        public Usuario Usuario { get; set; }
    }
}
