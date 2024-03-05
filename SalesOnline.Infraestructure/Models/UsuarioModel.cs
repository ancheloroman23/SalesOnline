using System;
using System.Collections.Generic;
using System.Text;

namespace SalesOnline.Infraestructure.Models
{
    public class UsuarioModel
    {
        public int idUsuario { get; set; }
        public string? nombreCompleto { get; set; }
        public string? correo {  get; set; }
        public string? clave { get; set; }
        public int? idRol {  get; set; }
        public DateTime? fechaRegistro { get;  set; }
    }
}
