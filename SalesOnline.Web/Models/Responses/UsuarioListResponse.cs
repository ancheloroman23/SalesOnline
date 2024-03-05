namespace SalesOnline.Web.Models.Responses
{
    public class UsuarioViewResult
    {
        public int idUsuario { get; set; }
        public string nombreCompleto { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
