using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }
        #region Constructores
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre, apellido, dni, nacionalidad)
        {
            this.Legajo = legajo;
        }
        public Universitario():base()
        {

        }
        #endregion

        /// <summary>
        /// Muestra atributos del objeto como string
        /// </summary>
        /// <returns>string </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("LEGAJO NUMERO: " + this.Legajo);
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Universitario) && this == (Universitario)obj;
        }
        #region Sobrecarga de operadores
        /// <summary>
        /// Comparo Dos Universitario que serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            /* if (pg1.GetType()==pg2.GetType() && (pg1.Dni==pg2.Dni || pg1.legajo==pg2.legajo))
             {
                 return true; 
             }*/
            
            return (pg1.Equals(pg2) && (pg1.Dni == pg2.Dni || pg1.legajo == pg2.legajo));
        }
      
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return (!(pg1 == pg2));
        }
        #endregion
    }
}
