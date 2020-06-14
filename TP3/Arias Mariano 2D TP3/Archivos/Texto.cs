using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;



namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo, true);

                sw.WriteLine(datos.ToString());
                sw.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
         
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader reader = new StreamReader(archivo, true);
                //string linea;
                // Console.WriteLine("\n\nLectura del archivo :");
                while ((datos = reader.ReadLine()) != null)
                {
                    Console.WriteLine(datos);
                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
           
        }

    }
}
