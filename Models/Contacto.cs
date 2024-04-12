using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCumpleaños { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Comprador Comprador { get; set; }
    }
}
