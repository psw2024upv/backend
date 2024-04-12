using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class ImagenProducto
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string Url { get; set; }
        public int IdArticulo { get; set; }

        [ForeignKey("IdArticulo")]
        public Articulo Articulo { get; set; }
    }
}
