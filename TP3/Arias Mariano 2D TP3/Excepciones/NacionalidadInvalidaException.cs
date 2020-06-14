using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException() : base ()
        {
           
        }
        public NacionalidadInvalidaException(string mensaje) : base("La Nacionalidad no se condice con el nùmero de DNI")
        {

        }
    }
}
