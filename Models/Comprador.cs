using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Comprador : Usuario
    {
        public int LimiteGastoCentsMes { get; set; }

    }
}
