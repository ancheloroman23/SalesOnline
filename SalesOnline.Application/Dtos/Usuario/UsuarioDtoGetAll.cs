using System;


namespace SalesOnline.Application.Dtos.Usuario
{
    public class UsuarioDtoGetAll
    {
        public int idUsuario { get; set; }
        public string? nombreCompleto { get; set; }
        public string? correo {  get; set; }
        public int? idRol { get; set; }
        public DateTime? fechaRegistro { get; set; }
        public bool? esActivo { get; set; }

    }

}
