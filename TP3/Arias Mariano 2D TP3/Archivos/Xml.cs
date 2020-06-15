using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using EntidadesAbstractas;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo">ruta</param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);

                XmlSerializer serializer = new XmlSerializer(typeof(T));  // ---<<< ACA FALLA 
                
               // XmlSerializer serializer = new XmlSerializer(typeof(T)), "Clases_instanciables");   
                serializer.Serialize(writer, datos);
               
                writer.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo">ruta </param>
        /// <param name="datos"></param>
        /// <returns></returns>
       public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = new XmlTextReader(archivo);
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
