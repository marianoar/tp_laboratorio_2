using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        #region Propiedades
       /// <summary>
       /// 
       /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); ; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ENacionalidad Nacionalidad { get { return nacionalidad; } set { nacionalidad = value; } }
        /// <summary>
        /// 
        /// </summary>
        public int Dni
        {
            get { return this.dni; }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {
           
        }
        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;

        }

        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.Dni = dni;
        }
        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDni = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida el dni dependiendo de la nacionalidad si es correcto caso contrario lanza excepcion
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retorna el dni</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dni;

            if (nacionalidad == (ENacionalidad)0 && dato >= 1 && dato <= 89999999)
            {
                dni = dato;
            }
            else if (nacionalidad == (ENacionalidad)1 && dato >= 90000000 && dato <= 99999999)
            {
                dni = dato;
            }
            else
            {
                throw new NacionalidadInvalidaException("La Nacionalidad no se condice con el Dni.");
            }
            return dni;
        }

        /// <summary>
        /// valida dni o lanza Exception
        /// </summary>
        /// <param name="nacionalidad">Enumerado nacionalidad </param>
        /// <param name="dato">recibe dni como sstring</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int resultado;

            if ((dato.Length <= 8)&&int.TryParse(dato, out int dni))
            {
                resultado = ValidarDni(nacionalidad, dni);
                if (resultado != 0)
                {
                    return resultado;
                }
            }

            throw new DniInvalidoException(" El Dni no es válido");
        }

        /// <summary>
        /// Valida que el string dato este compuesto por letras mediante char.IsLetter
        /// </summary>
        /// <param name="dato">dato que sera el atributo  nombre o apellido </param>
        /// <returns>si no es valido retorna Empty</returns>
        private string ValidarNombreApellido(string dato)
        {
            int aux = 0;
            for (int i = 0; i < dato.Length; i++)
            {
                if (!char.IsLetter(dato[i]))
                {
                    aux++;
                }
            }
            if (aux != 0)
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
            sb.Append("NOMBRE COMPLETO :" + apellido);
            sb.AppendLine(", " + nombre);
            //sb.Append(dni.ToString()); --> el ejemplo no muestra DNI
            sb.AppendLine("NACIONALIDAD: " + nacionalidad.ToString());
            return sb.ToString();
        }
        #endregion
    }
}