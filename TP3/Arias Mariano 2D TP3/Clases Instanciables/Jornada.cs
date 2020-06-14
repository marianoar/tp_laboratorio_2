using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using Excepciones;
using Archivos;

namespace EntidadesAbstractas
{
    public class Jornada
    {
        /*Atributos Profesor, Clase y Alumnos que toman dicha clase.
          • Se inicializará la lista de alumnos en el constructor por defecto.
          • Una Jornada será igual a un Alumno si el mismo participa de la clase.
          • Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente
          cargados.
          • ToString mostrará todos los datos de la Jornada.
          • Guardar de clase guardará los datos de la Jornada en un archivo de texto.
          • Leer de clase retornará los datos de la Jornada como texto*/

        private List<Alumno> alumnos;
        private Profesor instructor;
        private Universidad.EClases clase;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                alumnos = value;
            }
        }

        public Profesor Instructor
        {
            get 
            {
                return instructor;
            }
            set
            {
                instructor = value;
            }
        }

        public Universidad.EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }
        #endregion

        public Jornada (Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                string ruta = @".\TP3\Archivo.txt";

                Texto texto = new Texto();

                texto.Guardar(ruta, jornada.ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
        public static string Leer()
        {
            try
            {
                string ruta = @".\TP3\Archivo.txt";

                string lectura;

                Texto texto = new Texto();

                texto.Leer(ruta, out lectura);

                return lectura;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clase: "+clase.ToString());
            sb.AppendLine("Profesor: "+this.Instructor.ToString());
            sb.AppendLine("Alumnos:");
            for (int i = 0; i < alumnos.Count; i++)
            {
                sb.AppendLine(alumnos[i].ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// • Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.alumnos.Contains(a);   
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return (!(j == a));
        }
        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            // foreach (var item in j.alumnos)
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;    
        }
    }
}
