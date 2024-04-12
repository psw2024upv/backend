using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Comprador Comprador { get; set; }
    }
}
