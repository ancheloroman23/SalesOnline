using SalesOnline.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace SalesOnline.Domain.Entities
{
    public class Menu : BaseEntity
    {
        [Key]
        public int idMenu { get; set; }
        public String nombre { get; set; }
        public String? icono { get; set; }
        public String? url { get; set; }
    }
}
