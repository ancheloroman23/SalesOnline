using SalesOnline.Api.Models.Modules.Core;

namespace SalesOnline.Api.Models.Modules.Usuario
{
    public class UsuarioBaseModel : ModelBase
    {
        public string? nombreCompleto { get; set; }
        public string? correo { get; set; }
        public DateTime? fechaRegistro { get; set; }
        public bool? esActivo { get; set; }
    }
}
