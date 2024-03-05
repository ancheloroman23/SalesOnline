using SalesOnline.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace SalesOnline.Domain.Entities
{
    public class Usuario : Person
    {
        [Key]
        public int idUsuario { get; set; }
        public String? nombreCompleto { get; set; }
        public int? idRol { get; set; }
        public bool? esActivo { get; set; }
    }
}
