using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesOnline.Application.Contract;
using SalesOnline.Application.Core;
using SalesOnline.Application.Dtos.Usuario;
using SalesOnline.Application.Excepctions;
using SalesOnline.Application.Extentions;
using SalesOnline.Application.Response;
using SalesOnline.Application.Validations;
using SalesOnline.Domain.Entities;
using SalesOnline.Infraestructure.Interfaces;
using System;
using System.Linq;



namespace SalesOnline.Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogger<UsuarioService> logger;
        private readonly IConfiguration configuration;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              ILogger<UsuarioService> logger,
                              IConfiguration configuration)
        {
            this.usuarioRepository = usuarioRepository;
            this.logger = logger;
            this.configuration = configuration;
        }


        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.usuarioRepository.GetUsuarios();
            }
            catch (UsuarioServiceExcepcion uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los usuarios";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            result = UsuarioValidation.ValidateIdUsuario(id, configuration);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                result.Data = this.usuarioRepository.GetUsuario(id);
            }
            catch (UsuarioServiceExcepcion uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el usuario de id: {id}";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;

        }

        public ServiceResult Remove(UsuarioDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Usuario usuario = new Usuario()
                {
                    idUsuario = dtoRemove.idUsuario,
                    Eliminado = dtoRemove.Eliminado,
                    IdUsuarioElimino = dtoRemove.IdUsuarioMod,
                    FechaElimino = dtoRemove.FechaMod

                };
                this.usuarioRepository.Remove(usuario);

                result.Message = "El Usuario fue removido correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error Removido el Usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(UsuarioDtoAdd dtoAdd)
        {
            UsuarioResponse result = new UsuarioResponse();

            try
            {
                var validResult = dtoAdd.IsUsuarioValid(this.configuration);


                if (!validResult.Success)
                {
                    result.Success = validResult.Success;
                    result.Message = validResult.Message;
                    return result;
                }


                Usuario usuario = new Usuario()
                {
                    fechaRegistro = dtoAdd.FechaMod,
                    IdUsuarioCreacion = dtoAdd.IdUsuarioMod,
                    idRol = dtoAdd.idRol,
                    nombreCompleto = dtoAdd.nombreCompleto,
                    correo = dtoAdd.correo,
                    clave = dtoAdd.clave,
                    esActivo = dtoAdd.esActivo
                };

                this.usuarioRepository.Save(usuario);

                result.Message = this.configuration["MensajesUsuarioSuccess:AddSuccessMessage"];
                result.idUsuario = usuario.idUsuario;
            }
            catch (UsuarioServiceExcepcion ssex)
            {
                result.Success = false;
                result.Message = ssex.Message;
                this.logger.LogError(result.Message, ssex.ToString());

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["MensajesUsuarioSuccess:AddErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(UsuarioDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (string.IsNullOrEmpty(dtoUpdate.nombreCompleto))
                    throw new UsuarioServiceExcepcion(this.configuration["MensajeValidaciones:UsuarioNombreRequerido"]);


                if (dtoUpdate.nombreCompleto.Length > 100)
                    throw new UsuarioServiceExcepcion(this.configuration["MensajeValidaciones:UsuarioNombreLongitud"]);

                Usuario usuario = new Usuario()
                {
                    idUsuario = dtoUpdate.idUsuario,
                    nombreCompleto = dtoUpdate.nombreCompleto,
                    esActivo = dtoUpdate.esActivo,
                    idRol = dtoUpdate.idRol,
                    FechaMod = dtoUpdate.fechaRegistro,
                    correo = dtoUpdate.correo,
                    clave = dtoUpdate.clave,
                    IdUsuarioCreacion = dtoUpdate.IdUsuarioMod
                };
                this.usuarioRepository.Update(usuario);

                result.Message = "El Usuario fue actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error actualizado el Usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }


}
