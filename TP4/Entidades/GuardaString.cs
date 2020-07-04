using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /*GuardaString
            1. Crear un método de extensión para la clase String
            2. Este guardará en un archivo de texto en el escritorio de la máquina.
            3. Recibirá como parámetro el nombre del archivo.
            4. Si el archivo existe, agregará información en él*/

        /// <summary>
        /// guarda en un archivo de texto en el escritorio de la máquina. Si el archivo existe, agregará información
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo) {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            try
            {
                StreamWriter writer = new StreamWriter(Path.Combine(path, archivo), true, System.Text.Encoding.UTF8);
                writer.WriteLine(texto);
                writer.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
    }
}
