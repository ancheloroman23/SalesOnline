using SalesOnline.Application.Dtos.Base;

namespace SalesOnline.Application.Dtos.Usuario
{
    public class UsuarioDtoRemove : DtoBase
    {
        public string? nombreCompleto { get; set; }
        public int idUsuario { get; set; }
        public bool Eliminado { get; set; }
    }
}
