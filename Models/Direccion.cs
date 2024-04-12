using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string CodPostal { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int? Piso { get; set; }
        public string Puerta { get; set; }
        public string Indicaciones { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Comprador Comprador { get; set; }
    }
}
