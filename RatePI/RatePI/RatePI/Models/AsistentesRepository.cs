using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatePI.Models
{
    public class AsistentesRepository : Interface
    {
        internal void Save(Asistente asist)
        {
            bool increase = true;
            int check = 0;
            //Este metodo también sirve como comprobación, si no existe el proyecto no obtendrá el id y la inserción no funcionara.
            int idProyecto =  ProyectosRepository.RetrieveIdByProyect(asist.Proyecto); 

            MySqlConnection connection = Connect();
            string sql = "INSERT INTO `mydb`.`ASISTENTES` (`Email`, `NombreProyect`, `PuntuacionCei`, `PuntuacionPdi`, `PuntuacionComunicacion`, `idProyecto_fk`)" +
                " VALUES (@email, @proyecto, @PuntuacionCei, @PuntuacionPdi, @PuntuacionComunicacion, "+ idProyecto+"); ";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@email", asist.Email);
            command.Parameters.AddWithValue("@proyecto", asist.Proyecto);
            command.Parameters.AddWithValue("@PuntuacionCei", asist.PuntuacionCei);
            command.Parameters.AddWithValue("@PuntuacionPdi", asist.PuntuacionPdi);
            command.Parameters.AddWithValue("@PuntuacionComunicacion", asist.PuntuacionComunicacion);

            try
            {
                connection.Open();
                check = command.ExecuteNonQuery(); //insercion del asistente y su puntuacion
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error");
            }

            if (check > 0) //Solo ocurre si se realiza el insert
            {
                //Si el nombre del proyecto no existe, tampoco funcionara el update ya que filtra por nombre del poryecto.
                CategoriasRepository.UpdateCategorias(
                asist.PuntuacionCei, asist.PuntuacionPdi, asist.PuntuacionComunicacion, asist.Proyecto, increase); //Update para sumar la votacion
            }
        }



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

        public static int VotacionesPorProyecto(string proyecto)
        {
            MySqlConnection connection = Connect();
            string sql = "SELECT COUNT(NombreProyect) FROM asistentes WHERE asistentes.NombreProyect = '" + proyecto + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            int numVotaciones = 0;
            try
            {
                connection.Open();
                MySqlDataReader re = command.ExecuteReader();

                while (re.Read())
                {
                    numVotaciones = re.GetInt16(0);
                }
                return numVotaciones;
            }
            catch (MySqlException ex)
            {
                return 0;
            }
        }
    }
}