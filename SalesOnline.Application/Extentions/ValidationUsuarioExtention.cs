using Microsoft.Extensions.Configuration;
using SalesOnline.Application.Core;
using SalesOnline.Application.Dtos.Usuario;
using SalesOnline.Application.Excepctions;


namespace SalesOnline.Application.Extentions
{
    public static class ValidationUsuarioExtention
    {
        public static ServiceResult IsUsuarioValid(this UsuarioDtoBase dtoBase, IConfiguration configuration)
        {

            ServiceResult Result = new ServiceResult();

            if (string.IsNullOrEmpty(dtoBase.nombreCompleto))
                throw new UsuarioServiceExcepcion(configuration["MensajeValidaciones:UsuarioNombreRequerido"]);


            if (dtoBase.nombreCompleto.Length > 50)
                throw new UsuarioServiceExcepcion(configuration["MensajeValidaciones:UsuarioNombreLongitud"]);

            if (string.IsNullOrEmpty(dtoBase.correo))
                throw new UsuarioServiceExcepcion(configuration["MensajeValidaciones:UsuarioCorreoRequerido"]);

            if (dtoBase.correo.Length > 50)
                throw new UsuarioServiceExcepcion(configuration["MensajeValidaciones:UsuarioCorreoApellidoLongitud"]);

            if (!dtoBase.fechaRegistro.HasValue)
                throw new UsuarioServiceExcepcion(configuration["MensajeValidaciones:UsuarioFechaRegistroRequerido"]);



            return Result;
        }
    }
}

