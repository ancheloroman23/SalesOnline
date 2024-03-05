using SalesOnline.Domain.Entities;
using System.Collections.Generic;

namespace SalesOnline.Infraestructure.Repository
{
    public interface IUsuarioRepository
    {
        void Save(Usuario usuario);
        void Update(Usuario usuario);
        void Remove(Usuario usuario);
        List<Usuario> GetUsuarios();
        Usuario GetUsuario(int id);
    }
}