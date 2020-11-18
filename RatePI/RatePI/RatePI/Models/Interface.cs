using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatePI.Models
{
    public class Interface
    {
        public static MySqlConnection Connect()
        {
            //Conexión Local
            string server = "server=127.0.0.1;";
            string port = "port=3306;";
            string database = "database=mydb;";
            string usuario = "uid=root;";
            string password = "pwd=;";
            string datetime = "Convert Zero Datetime = True";
            string conString = server + port + database + usuario + password + datetime;

            MySqlConnection con = new MySqlConnection(conString);
            return con;
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