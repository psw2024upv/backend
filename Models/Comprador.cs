using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("comprador")]
    public class Comprador : BaseModel
    {
        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        [Column("limite_gasto_cents_mes")]
        public int Limite_gasto_cents_mes { get; set; }

        // Propiedad de navegación hacia el Usuario
        public Usuario Usuario { get; set; }
    }
}
