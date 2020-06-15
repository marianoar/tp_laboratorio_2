using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException):base ("Excepcion, No se ha guardado el archivo", innerException)
        {

        }
        /// <summary>
        /// Constructor sinparametros por defecto
        /// </summary>
        public ArchivosException() : base()
        {

        }
    }
}
