using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using TP4_AriasMariano_2D;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// verifico que la lista de Paquetes del Correo esté instanciada
        /// </summary>
        [TestMethod]
        public void VerificarListaPaquetesInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// verifico que no se puedan cargar dos Paquetes con el mismo Tracking ID
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIDRepetidoException))]
        public void VerificarPaqueteDuplicado()
        {
            Correo correo = new Correo();
           
            Paquete paquete1 = new Paquete("Mitre 123", "123-123-1234");
            Paquete paquete2 = new Paquete("Alsino 345", "123-123-1234");

            correo += paquete1;
            correo += paquete2;

            // en verdad no llega a este punto pues deberia lanzar la excepcion antes
            Assert.AreEqual(paquete1, paquete2);
        }
    }
}
