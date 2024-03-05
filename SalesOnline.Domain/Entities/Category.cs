

using SalesOnline.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesOnline.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Key]
        public int idCategoria { get; set; }
        public string? nombre { get; set; }
        public bool? esActivo { get; set; }
        public DateTime? fechaRegistro { get; set; }

        public List<Producto> productos { get; set; }


    }
}
