using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("resena")]
    public class Resena : BaseModel
    {
        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("puntuacion")]
        public string Puntuacion { get; set; }

        [Column("texto")]
        public string Texto { get; set; }

        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        [Column("id_producto")]
        public int Id_producto { get; set; }

        // Propiedad de navegación hacia el Comprador
        public Comprador Comprador { get; set; }

        // Propiedad de navegación hacia el Producto
        public Producto Producto { get; set; }

        // Clave primaria compuesta
        [PrimaryKey]
        public (int, int) CompositeKey { get; set; }
    }
}
