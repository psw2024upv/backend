﻿using Postgrest.Attributes;
using Postgrest.Models;

namespace backend.Models
{
    [Table("productos")]
    public class Producto : BaseModel
    {
        [PrimaryKey("Id", false)]
        public int Id { get; set; }


        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Precio")]
        public int Precio { get; set; }
        // Otros campos que puedas necesitar


        // Relación con Cliente si es necesario

    }
}
