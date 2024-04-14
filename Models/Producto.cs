using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("producto")]
    public class Producto : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }


        [Column("precio_cents")]
        public int Precio_cents { get; set; }

        [Column("unidades")]
        public int Unidades { get; set; }

        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        [Column("id_articulo")]
        public int Id_articulo { get; set; }

        public Vendedor Vendedor { get; set; }
        /*
        C:\Users\marius\Documents\proyectosPersonales\psw\backend\Logica\LogicaClase.cs(338,61): error CS1061: 
        'Producto' does not contain a definition for 'Articulo' and no accessible extension method 'Articulo' 
        accepting a first argument of type 'Producto' could be found (are you missing a using directive or
         an assembly reference?) [C:\Users\marius\Documents\proyectosPersonales\psw\backend\backend.csproj]
        */

        public Articulo Articulo { get; set; }

    }
}
