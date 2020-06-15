using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_instanciables;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // prueba 
        public void TestInstanciarAlumno()
        {
            Alumno alumno = new Alumno(1, "Mariano", "Arias", "22222333", 0, 0);
            Assert.IsNotNull(alumno);
        }

        //Generar al menos uno que valide se haya instanciado un atributo del tipo colección en alguna de las clases dadas.
        
        [TestMethod]
        public void TestAtributosTipoColeccion()
        {
            Universidad universidad = new Universidad(); 
            Alumno alumno = new Alumno(1, "Mariano", "Arias", "22222333", 0, 0);
            universidad.Alumnos.Add(alumno);
            Assert.IsNotNull(universidad.Alumnos);
        }


        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesorException()
        {

            Profesor instructor = new Profesor(1, "Mariano", "Arias", "22222333", 0);
            Alumno alumno = new Alumno(1, "Mariano", "Arias", "22222333", 0, 0);
            Universidad universidad = new Universidad();
            universidad += instructor;
            universidad += alumno;
            universidad += Universidad.EClases.Laboratorio;
            universidad += Universidad.EClases.Programacion;
            universidad += Universidad.EClases.SPD;
            universidad += Universidad.EClases.Legislacion;
        }


        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestArchivosException()
        {
            Universidad universidad = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Universidad.xml";
            xml.Guardar(archivo, universidad);
        }

    }
}
