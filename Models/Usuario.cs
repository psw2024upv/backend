using Postgrest.Attributes;
using Postgrest.Models;
using System.Collections.Generic;

namespace backend.Models
{
    [Table("usuario")]
    public class Usuario : BaseModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("nick_name")]
        public string NickName { get; set; }

        [Column("contraseña")]
        public string Contraseña { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("edad")]
        public int Edad { get; set; }

        // // Relación con FotoPerfil
        // public List<FotoPerfil> FotoPerfiles { get; set; }

        // // Relación con Alertas
        // public List<Alerta> Alertas { get; set; }

        // // Relación con Notificaciones
        // public List<Notificacion> Notificaciones { get; set; }

        // // Otras relaciones que puedas necesitar
    }
}
