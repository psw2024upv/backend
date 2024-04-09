using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("direccion")]
    public class Direccion : BaseModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("pais")]
        public string Pais { get; set; }

        [Column("provincia")]
        public string Provincia { get; set; }

        [Column("ciudad")]
        public string Ciudad { get; set; }

        [Column("cod_postal")]
        public string Cod_postal { get; set; }

        [Column("calle")]
        public string Calle { get; set; }

        [Column("numero")]
        public int Numero { get; set; }

        [Column("piso")]
        public int? Piso { get; set; }

        [Column("puerta")]
        public string Puerta { get; set; }

        [Column("indicaciones")]
        public string Indicaciones { get; set; }

        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        // Propiedad de navegación hacia el Comprador
        public Comprador Comprador { get; set; }
    }
}
