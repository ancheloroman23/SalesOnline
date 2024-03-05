using System;

namespace SalesOnline.Domain.Core
{
    public abstract class Person : BaseEntity
    {
        public DateTime? fechaRegistro { get; set; }
        public String? correo { get; set; }
        public String? clave { get; set; }


    }
}
