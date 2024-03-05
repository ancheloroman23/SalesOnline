using SalesOnline.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace SalesOnline.Domain.Entities
{
    public class DetalleVenta : BaseEntity
    {
        [Key]
        public int idDetalleVenta { get; set; }
        public int? idVenta { get; set; }
        public int? idProducto { get; set; }
        public int cantidad { get; set; }
        public decimal? precio { get; set; }
        public decimal? total { get; set; }


    }
}
