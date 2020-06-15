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
        /// Constructor po defecto
        /// </summary>
        public NacionalidadInvalidaException() : base(" ")
        {

        }

        /// <summary>
        /// Constructor mensaje personalizado
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
    }
}
