using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int EdadMin { get; set; }
        public string ConsejosUtilizacion { get; set; }
        public string ConsejosRetirada { get; set; }
        public string Origen { get; set; }
        public string ProcesoProduccion { get; set; }
        public string ImpactoAmbientalSocial { get; set; }
        public string ContribucionOds { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Productor Productor { get; set; }
    }
}
