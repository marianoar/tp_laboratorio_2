using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;

        #region Propiedades
        public string Apellido { 
            get 
            { 
                return apellido; 
            } 
            set 
            {
                apellido = this.ValidarNombreApellido(value); 
            } 
        }
        public string Nombre { 
            get 
            { 
                return nombre; 
            } 
            set 
            { 
                nombre = this.ValidarNombreApellido(value); 
            } 
        }

        public int Dni
        {
            get
            {
                return dni;
            }
            set
            {
                dni = ValidarDNI(nacionalidad, value);
                if (dni == 0) 
                {
                    throw new DniInvalidoException();
                }
             }
        }
        public ENacionalidad Nacionalidad { get { return nacionalidad; } set { nacionalidad = value; } }

        public string StringToDNI { 
            set 
            {
                dni = ValidarDNI(nacionalidad, value);
            } 
        } // corregir
        #endregion

        # region Constructores
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this (nombre, apellido, nacionalidad)
        {  
            this.Dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            StringToDNI = dni;
            this.nacionalidad = nacionalidad;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        { 
            int dni = 0;
            if (nacionalidad == ENacionalidad.Argentino && dato>1 && dato<89999999)
            {
                dni = dato;
            } else if ((nacionalidad == (ENacionalidad)1) && (dato > 90000000 && dato < 99999999))
            {
                dni= dato;
            }
            else
            {
               /* Esta comentado porq No hace la excepcion por consola e interrumpe la ejecucion */

              // throw new NacionalidadInvalidaException ();
            }
            return dni;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            if((dato.Length<=8) && (int.TryParse(dato, out int aux)))
            {
                return this.ValidarDNI(nacionalidad,aux);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }
        /// <summary>
        /// Valida que el string dato este compuesto por letras mediante char.IsLetter
        /// </summary>
        /// <param name="dato">dato que sera el atributo  nombre o apellido </param>
        /// <returns>si no es valido retorna Empty</returns>
        private string ValidarNombreApellido (string dato)
        {
            int aux = 0;
            for (int i = 0; i < dato.Length; i++)
            {
                if (!char.IsLetter(dato[i])){
                    aux++;
                }
            }
            if (aux!=0)
            {
                dato = string.Empty;
                return dato;
            }
            else
            {
                return dato;
            }
        }
        /// <summary>
        /// Override de ToString 
        /// </summary>
        /// <returns>atributos apellido, nombre y nacionalidad como strings</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("NOMBRE COMPLETO :"+apellido);
            sb.AppendLine(", "+nombre);
            //sb.Append(dni.ToString());
            sb.AppendLine("NACIONALIDAD: "+nacionalidad.ToString());
            return sb.ToString();
        }
        #endregion
    }
}
