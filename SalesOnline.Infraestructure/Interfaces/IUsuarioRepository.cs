using SalesOnline.Domain.Entities;
using SalesOnline.Domain.Repository;
using SalesOnline.Infraestructure.Models;
using System.Collections.Generic;

namespace SalesOnline.Infraestructure.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        public List<UsuarioModel> GetUsuarios();
        public UsuarioModel GetUsuario(int id);
    }
}
