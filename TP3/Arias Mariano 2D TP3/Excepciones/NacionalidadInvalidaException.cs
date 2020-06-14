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
        /// Constructor por defecto
        /// </summary>
        public NacionalidadInvalidaException( ) : base()
        {

        }
        /// <summary>
        /// Mensaje error personalizado
        /// </summary>
        public NacionalidadInvalidaException(string mensaje) : base ("La Nacionalidad no se condice con el nùmero de DNI")
        {

        }
        

        /*
        //string message = 
        public NacionalidadInvalidaException() : base("La Nacionalidad no se condice con el nùmero de DNI")
        {

        }
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
   */
        /*
             public NacionalidadInvalidaException(string Message)
              : base(Message) { }
             public NacionalidadInvalidaException()
                 : this("La nacionalidad no se condice con el numero de DNI") { }
     */
    }
}
