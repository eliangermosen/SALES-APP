using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructure.Exceptions
{
    public class UsuarioException : Exception
    {
        public UsuarioException(string message) : base(message)
        {
            //logica para almacenar la exception
        }
    }
}
