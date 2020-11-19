using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatePI.Models
{
    public class AsistentesRepository : Interface
    {
        internal void DeleteByEmail(string email)
        {
            //obtener nombre y puntuacion del asistente para erealizar el update donde se almacena el total de las votaciones.
            MySqlConnection connection = Connect();
            string sqlSelect = "SELECT NombreProyect, PuntuacionCei, PuntuacionPdi, PuntuacionComunicacion FROM asistentes WHERE asistentes.Email = @email;";
            MySqlCommand commandS = new MySqlCommand(sqlSelect, connection);
            commandS.Parameters.AddWithValue("@email", email);
            string proyecto = "";
            int puntuacionCei = 0, puntuacionPdi = 0, puntuacionComunicacion = 0;
            bool increase = false;
            try
            {
                connection.Open();
                MySqlDataReader re = commandS.ExecuteReader();
                while (re.Read())
                {
                    proyecto = re.GetString(0);
                    puntuacionCei = re.GetInt16(1);
                    puntuacionPdi = re.GetInt16(2);
                    puntuacionComunicacion = re.GetInt16(3);
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error");
            }

            //Update de las votaciones
            CategoriasRepository.UpdateCategorias(puntuacionCei, puntuacionPdi, puntuacionComunicacion, proyecto, increase);

            //Delete
            string sqlDelete = "DELETE FROM asistentes WHERE asistentes.Email = @email;";
            MySqlCommand commandD = new MySqlCommand(sqlDelete, connection);
            commandD.Parameters.AddWithValue("@email", email);

            try
            {
                connection.Open();
                commandD.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error");
            }
        }
    }
}