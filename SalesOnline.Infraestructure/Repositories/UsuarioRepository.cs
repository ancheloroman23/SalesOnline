﻿using SalesOnline.Domain.Entities;
using SalesOnline.Infraestructure.Context;
using SalesOnline.Infraestructure.Core;
using SalesOnline.Infraestructure.Interfaces;
using SalesOnline.Infraestructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesOnline.Infraestructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SalesContext context;

        public UsuarioRepository(SalesContext context) : base(context)
        {
            this.context = context;
        }
               
        public override List<Usuario> GetEntities()
        {
            return base.GetEntities().Where(usu => !usu.Eliminado).ToList();
        }

        public override void Save(Usuario entity)
        {
            base.Save(entity);
            this.context.SaveChanges();
        }

        public override void Update(Usuario entity)
        {
            Usuario usuario = this.GetEntity(entity.idUsuario);

            usuario.idUsuario = entity.idUsuario;
            usuario.FechaMod = entity.FechaMod;
            usuario.IdUsuarioMod = entity.IdUsuarioMod;
            usuario.nombreCompleto = entity.nombreCompleto;
            usuario.correo = entity.correo;
            usuario.clave = entity.clave;
            usuario.idRol = entity.idRol;

            this.context.Usuario.Update(usuario);
            this.context.SaveChanges();

        }
        

        public override void Remove(Usuario entity)
        {
            Usuario usuario = this.GetEntity(entity.idUsuario);

            usuario.idUsuario = entity.idUsuario;
            usuario.Eliminado = entity.Eliminado = true;
            usuario.IdUsuarioElimino = entity.IdUsuarioElimino;
            usuario.FechaElimino = entity.FechaElimino;

            this.context.Usuario.Update(usuario);
            this.context.SaveChanges();
        }

        public List<UsuarioModel> GetUsuarios()
        {
            var usuarios = this.context.Usuario
                             .Where(usu => !usu.Eliminado)
                             .OrderByDescending(usu => usu.fechaRegistro)
                             .Select(usu => new UsuarioModel
                             {
                                 fechaRegistro = usu.fechaRegistro,
                                 idRol = usu.idRol,
                                 nombreCompleto = usu.nombreCompleto,
                                 correo = usu.correo,
                                 idUsuario = usu.idUsuario,
                             })
                                .ToList();

            return usuarios;
        }

        public UsuarioModel GetUsuario(int idUsuario)
        {
            var usuarios = this.GetUsuarios();
            return usuarios.Find(s => s.idUsuario == idUsuario);
        }
    }
}