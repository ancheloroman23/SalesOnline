using SalesOnline.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace SalesOnline.Domain.Entities
{
    public class Producto : BaseEntity
    {
        [Key]
        public int idProducto { get; set; }
        public int? idCategoria { get; set; }
        public int? stock { get; set; }
        public decimal precio { get; set; }
        public bool? esActivo { get; set; }

        public Category categoria { get; set; }

    }
}
