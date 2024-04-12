using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class FotoPerfil
    {
        public string Hash { get; set; }
        public string Url { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}
