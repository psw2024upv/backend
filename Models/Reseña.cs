using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Reseña
    {
        public string Titulo { get; set; }
        public string Puntuacion { get; set; }
        public string Texto { get; set; }
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }

        [ForeignKey("IdUsuario")]
        public Comprador Comprador { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
    }
}
