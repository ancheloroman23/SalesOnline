namespace SalesOnline.Web.Models.Responses
{
    public class UsuarioDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public UsuarioViewResult data { get; set; }
    }
}
