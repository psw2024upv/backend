using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("pedido")]
    public class Pedido : BaseModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        // Propiedad de navegación hacia el Comprador
        public Comprador Comprador { get; set; }
    }
}
