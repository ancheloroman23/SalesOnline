namespace SalesOnline.Api.Models.Modules.Usuario
{
    public class GetUsuarioModel
    {
        public int IdUsuarioCreacion { get; set; }
        public string? nombreCompleto { get; set; }
        public string? correo { get; set; }
        public string? clave { get; set; }
        public DateTime? fechaRegistro { get; set; }
    }
}
