using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
      
        /// <summary>
        /// Mensaje error personalizado
        /// </summary>
        public NacionalidadInvalidaException(string mensaje) : base ()
        {

        }

        public NacionalidadInvalidaException() : base("La nacionalidad no se condice con el número de DNI")
        {

        }
    }
}
