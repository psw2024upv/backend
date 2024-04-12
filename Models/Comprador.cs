using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("comprador")]
    public class Comprador : Usuario
    {
        [PrimaryKey]
        [Column("id_usuario")]
        public int Id { get; set; }


        [Column("limite_gasto_cents_mes")]
        public string Limite_gasto_cents_mes { get; set; }

        
        // Otros campos que puedas necesitar


        // Relación con Cliente si es necesario

    }
}