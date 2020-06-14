﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public class Profesor : Universitario
    {

        /*  Atributos ClasesDelDia del tipo Cola y random del tipo Random y estático.
           • Sobrescribir el método MostrarDatos con todos los datos del profesor.
           • ParticiparEnClase retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
           • ToString hará públicos los datos del Profesor.
           • Se inicializará a Random sólo en un constructor.
           • En el constructor de instancia se inicializará ClasesDelDia y se asignarán dos clases al azar al Profesor
           mediante el método randomClases. Las dos clases pueden o no ser la misma.
           • Un Profesor será igual a un EClase si da esa clase*/

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        static Profesor()
        {
            random = new Random();
        }

        public Queue<Universidad.EClases> ClasesDelDia
        {
            get
            {
                return clasesDelDia;
            }
            set
            {
                clasesDelDia = value;
            }
        }

        private void _randomClases()
        {
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }
        //En el constructor de instancia se inicializará ClasesDelDia y se asignarán dos clases al azar al Profesor
        // mediante el método randomClases.Las dos clases pueden o no ser la misma.
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(legajo:id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        public Profesor() : base()
        {

        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
             
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Universidad.EClases clases in this.clasesDelDia)
            {
                sb.AppendLine(clases.ToString());
            }
            return sb.ToString();
            
        }

        //• Un Profesor será igual a un EClase si da esa clase*/
        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return (!(i == clase));
        }
    }
}
