using SalesOnline.Application.Core;
using SalesOnline.Application.Dtos.Usuario;

namespace SalesOnline.Application.Contract
{
    public interface IUsuarioService : IBaseService<UsuarioDtoAdd, UsuarioDtoUpdate, UsuarioDtoRemove>
    {


    }
}
