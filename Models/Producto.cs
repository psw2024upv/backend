using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int PrecioCents { get; set; }
        public int Unidades { get; set; }
        public int IdUsuario { get; set; }
        public int IdArticulo { get; set; }

        [ForeignKey("IdUsuario")]
        public Vendedor Vendedor { get; set; }

        [ForeignKey("IdArticulo")]
        public Articulo Articulo { get; set; }
    }
}
