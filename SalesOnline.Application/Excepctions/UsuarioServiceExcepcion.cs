using System;

namespace SalesOnline.Application.Excepctions
{
    public class UsuarioServiceExcepcion : Exception
    {
        public UsuarioServiceExcepcion(string message) : base(message)
        {
            // realizar x logica //
        }
    }
}
