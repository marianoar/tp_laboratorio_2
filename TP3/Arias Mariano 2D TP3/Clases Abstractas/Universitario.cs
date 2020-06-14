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
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre, apellido, dni, nacionalidad)
        {
            this.Legajo = legajo;
        }
        public Universitario():base()
        {

        }


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
            //return (this == (Universitario)obj);
            return obj.GetType() == typeof(Universitario) && this == (Universitario)obj;
        }

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
    }
}
