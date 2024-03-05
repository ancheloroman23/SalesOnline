using SalesOnline.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace SalesOnline.Domain.Entities
{
    public class Rol : BaseEntity
    {
        [Key]
        public int idRol { get; set; }
        public String? nombre { get; set; }


    }
}
