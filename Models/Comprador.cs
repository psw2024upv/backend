using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("comprador")]
    public class Comprador : Usuario
    {


        [Column("limite_gasto_cents_mes")]
        public int Limite_gasto_cents_mes { get; set; }

        
        // Otros campos que puedas necesitar


        // Relación con Cliente si es necesario

    }
}