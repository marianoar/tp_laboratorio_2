using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_instanciables
{
    public sealed class Alumno : Universitario
    {
        /*Atributos ClaseQueToma del tipo EClase y EstadoCuenta del tipo EEstadoCuenta.
        • Sobreescribirá el método MostrarDatos con todos los datos del alumno.
        • ParticiparEnClase retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
        • ToString hará públicos los datos del Alumno.
        • Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        • Un Alumno será distinto a un EClase sólo si no toma esa clase*/


        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        public Alumno (int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma): base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno() : base()
        {

        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Estado de Cuenta: "+estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma.ToString();
        }

    
        //Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return ((a.estadoCuenta.ToString()!="Deudor") && (a.claseQueToma==clase));
        }
        //Un Alumno será distinto a un EClase sólo si no toma esa clase*/
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (!(a.claseQueToma == clase));
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
    }

    
}
