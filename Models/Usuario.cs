using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NickName { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
    }
}
