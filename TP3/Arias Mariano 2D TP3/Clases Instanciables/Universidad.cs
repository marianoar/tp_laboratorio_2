﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using EntidadesAbstractas;
using Archivos;
using System.Xml;
using System.Xml.Serialization;

namespace Clases_instanciables
{
  
    public class Universidad
    {
        /* Atributos Alumnos (lista de inscriptos), Profesores (lista de quienes pueden dar clases) y Jornadas.
           • Se accederá a una Jornada específica a través de un indexador.
           • Un Universidad será igual a un Alumno si el mismo está inscripto en él.
           • Un Universidad será igual a un Profesor si el mismo está dando clases en él.
           • Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
           clase, un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la
           toman (todos los que coincidan en su campo ClaseQueToma).
           • Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente
           cargados.• La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
           Sino, lanzará la Excepción SinProfesorException. El distinto retornará el primer Profesor que no
           pueda dar la clase.
           • Si al querer agregar alumnos este ya figura en la lista, lanzar la excepción AlumnoRepetidoException.
           • MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante
           ToString.
           • Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus
           Profesores, Alumnos y Jornadas.
           • Leer de clase retornará un Universidad con todos los datos previamente serializados.*/

         /// <summary>
         /// Enumerado con las clases posibles
         /// </summary>
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;

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
        public List<Profesor> Instructores
        {
            get
            {
                return profesores;
            }
            set
            {
                profesores = value;
            }
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return jornada;
            }
            set
            {
                jornada = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                return this.Jornadas[i];
            }
            set
            {
                this.Jornadas[i] = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros, inicializa las colecciones
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
            jornada = new List<Jornada>();
        }
        #endregion

       # region Sobrecarga de operadores
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        public static bool operator!=(Universidad g, Alumno a)
        {
            return (!(g == a));
        }
        public static bool operator==(Universidad g, Alumno a) 
        {
            for (int i = 0; i < g.alumnos.Count; i++)
            {
                if (g.Alumnos[i].Dni== a.Dni) // revisar, deberia funcionar sin llamar a dni
                {
                    return true;
                }else
                {
                    continue;
                }
            }
            return false;
        }

        public static bool operator!=(Universidad g, Profesor i)
        {
            return (!(g == i));
        }
        /// <summary>
        ///  Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator==(Universidad g, Profesor i) 
        {
            return g.Instructores.Contains(i);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.profesores)
            {
                if (p == clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();

        }
        public static Profesor operator != (Universidad u, EClases clase) 
        {
            foreach (Profesor p in u.profesores)
            {
                if (p != clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            else
            {
                throw new SinProfesorException();
            }

            return g;
        }
        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la 
        /// clase, un Profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la
        /// toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor;
            profesor = (g == clase); //esta sobrecarga me devuelve un profesor
            Jornada jornada = new Jornada(clase, profesor);

            List<Alumno> alumnos = new List<Alumno>();

            for (int i = 0; i < g.alumnos.Count; i++)
            {
                if (g.alumnos[i] == clase)  // va a la sobrecarga de clase Alumno y compara
                {
                    alumnos.Add(g.alumnos[i]); // y si coinciden las clases lo agrego a la lista
                }
            }

            jornada.Alumnos = alumnos; // la lista que cree aca la sumoa a la nueva jornada.

            g.Jornadas.Add(jornada);

            return g;


        }
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido...");
            }
            return g;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo estatico que los datos
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
                sb.AppendLine("<----------------------------->");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        /// <summary>
        /// Metodo estatico Guarda objeto Universidad en un archivo xml en el desktop de la pc
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            try
            { 
                Xml<Universidad> xml = new Xml<Universidad>();
                string archivo = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Universidad.xml";
                return xml.Guardar(archivo, uni);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Metodo estatico Lee archivo xml 
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad uni;

            Xml<Universidad> xmlReader = new Xml<Universidad>();
            xmlReader.Leer(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Universidad.xml", out uni);

            return uni;
        }
        #endregion
    }
}
