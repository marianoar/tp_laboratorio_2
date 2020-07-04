using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Paquete> paquetes;
        private List<Thread> mockPaquetes;

        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete p in ((Correo)elementos).Paquetes)
            {
                sb.AppendFormat("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga operador + . Sumo un paquete a la lista de paquetes de Correo. Si esta repetio lanzo excepcion
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            if (!(c is null | p is null))
            {
                for (int i = 0; i < c.Paquetes.Count; i++)
                {
                    if(c.Paquetes[i] == p)
                    {
                        throw new TrackingIDRepetidoException("El paquete Id nº"+p.TrackingID+" se encuentra repetido. \n No puede haber dos paquetes con un mismo ID");
                    }
                }

                c.Paquetes.Add(p);
                Thread t = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(t);
                t.Start();
            }
            return c;
        }

        /// <summary>
        /// cerrará todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            if (mockPaquetes != null)
            {
                foreach (Thread t in mockPaquetes)
                    t.Abort();
            }
        }


    }
}
