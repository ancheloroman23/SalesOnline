

using SalesOnline.Application.Dtos.Base;
using System;

namespace SalesOnline.Application.Dtos.Usuario
{
    public class UsuarioDtoBase : DtoBase
    {
        public string? nombreCompleto { get; set; }
        public string? correo { get; set; }
        public string? clave { get; set; }
        public int? idRol { get; set; }
        public DateTime? fechaRegistro { get; set; }
        public bool? esActivo { get; set; }
    }
}

