using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        /*Clase estática que se encargará de guardar los datos de un paquete en la base de datos provista.
         A. De surgir cualquier error con la carga de datos, se deberá lanzar una excepción y controlarla en el
         método que la haya llamado, sin realizar ninguna acción con esta.
         B. El campo alumno de la base de datos deberá contener el nombre del alumno que está realizando el examen*/

        static SqlCommand command;
        static SqlConnection connection;

        static PaqueteDAO()
        {

        }

        public static bool Insertar (Paquete p)
        {
            string alumno = "AriasMariano";
            try
            {
                command = new SqlCommand();
                connection = new SqlConnection();

                connection.ConnectionString = @"Data Source=DESKTOP-NT5B90I\SQLEXPRESS; Initial Catalog=correo-sp-2017;Integrated Security=True";
                connection.Open();
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("direccion", p.DireccionEntrega));
                command.Parameters.Add(new SqlParameter("tracking", p.TrackingID));
                command.Parameters.Add(new SqlParameter("alumno", alumno));
                command.CommandText = "Insert into Paquetes (direccionEntrega, trackingID, alumno) values (@direccion, @tracking, @alumno)";

                SqlDataReader sqlDataReader = command.ExecuteReader();
               
            }
            catch(Exception ex)
            {
                throw new Exception("Error en la conexion a la base de datos", ex);
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}
