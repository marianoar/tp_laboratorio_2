using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino) && ((dato>1 && dato<89999999)))
            {
                return dato;
            } else if ((nacionalidad == ENacionalidad.Extranjero) && ((dato > 90000000 && dato < 99999999)))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }

        }

        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            if((dato.Length<=8) && (int.TryParse(dato, out int aux)))
            {
                return aux;
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

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

        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(apellido);
            sb.Append(nombre);
            sb.Append(dni.ToString());
            sb.Append(nacionalidad);
            return sb.ToString();
        }
    }
}
