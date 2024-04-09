using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("listadeseos")]
    public class ListaDeseos : BaseModel
    {
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
