using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using Excepciones;
using Archivos;
using EntidadesAbstractas;

namespace Clases_instanciables
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

        #region Constructores
        public Jornada (Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        /// <summary>
        ///  constructor privado, inicializa la lista alumnos
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        #endregion

        /// <summary>
        /// Metodo estatico Guarda objeto Jornada en un archivo txt en el desktop de la pc
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                //string ruta =  ".\\Archivo.txt";
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Archivo.txt";
                Texto texto = new Texto();

                texto.Guardar(ruta, jornada.ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
        /// <summary>
        /// Metodo estatico Lee archivo txt en el desktop de la pc
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            try
            {
                                /*              voy al escritorio de la pc                        */
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Archivo.txt";

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
        /// <summary>
        /// Override de ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            sb.Append("CLASE DE: "+clase.ToString());
            sb.AppendLine(" POR "+this.Instructor.ToString());
            
            sb.AppendLine("Alumnos:");
            for (int i = 0; i < alumnos.Count; i++)
            {
                sb.AppendLine(alumnos[i].ToString());
            }
            return sb.ToString();
        }

        #region Sobrecarga operadores
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
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
        /// Agrega Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
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
        #endregion
    }
}
