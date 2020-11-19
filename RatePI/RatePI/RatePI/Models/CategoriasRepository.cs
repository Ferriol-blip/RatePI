using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatePI.Models
{
    public class CategoriasRepository : Interface
    {
        internal List<CategoriaDTO> RetrieveByCategoria(string categoria)
        {
            MySqlConnection connection = Connect();
            string sql = "SELECT categorias.Proyecto, categorias.Categoria, categorias.PuntuacionTotal from categorias WHERE categorias.categoria = '"+categoria+"';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<CategoriaDTO> list = new List<CategoriaDTO>();
            CategoriaDTO obj;
       
            try
            {
                connection.Open();
                MySqlDataReader re = command.ExecuteReader();
                while (re.Read())
                {
                    string proyecto = re.GetString(0);
                    int puntuacion = re.GetInt16(2);
                    int votaciones = AsistentesRepository.VotacionesPorProyecto(proyecto);
                    double media = 0;
                    media = puntuacion != 0 ? media = puntuacion / votaciones : media;

                    obj = new CategoriaDTO(re.GetString(0), re.GetString(1), media);
                    list.Add(obj);
                }
                connection.Close();
                return list;
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }

        internal List<CategoriaDTO> RetrieveByProyecto(string proyecto)
        {
            MySqlConnection connection = Connect();
            string sql = "SELECT categorias.Proyecto, categorias.Categoria, categorias.PuntuacionTotal from categorias WHERE categorias.proyecto = '" + proyecto + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<CategoriaDTO> list = new List<CategoriaDTO>();
            CategoriaDTO obj;

            try
            {
                connection.Open();
                MySqlDataReader re = command.ExecuteReader();
                while (re.Read())
                {
                    obj = new CategoriaDTO(re.GetString(0), re.GetString(1), re.GetInt16(2));
                    list.Add(obj);
                }
                connection.Close();
                return list;
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }

        internal void InsertCategorias(int id, string nombre)
        {
            MySqlConnection connection = Connect();
            string sql1 = "INSERT INTO `mydb`.`CATEGORIAS` (`idProyecto_fk`, `Categoria`, `PuntuacionTotal`, `Proyecto`) VALUES ("+ id +", 'creatividad', 0, '"+nombre+"');";
            string sql2 = "INSERT INTO `mydb`.`CATEGORIAS` (`idProyecto_fk`, `Categoria`, `PuntuacionTotal`, `Proyecto`) VALUES (" + id + ", 'implementacion', 0, '" + nombre + "');";
            string sql3 = "INSERT INTO `mydb`.`CATEGORIAS` (`idProyecto_fk`, `Categoria`, `PuntuacionTotal`, `Proyecto`) VALUES (" + id + ", 'comunicacion', 0, '" + nombre + "');";
            MySqlCommand command1 = new MySqlCommand(sql1, connection);
            MySqlCommand command2 = new MySqlCommand(sql2, connection);
            MySqlCommand command3 = new MySqlCommand(sql3, connection);

            try
            {
                connection.Open();
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error");
            }
        }

        public static  void UpdateCategorias(int puntuacionCei, int puntuacionPdi, int puntuacionComunicacion, string proyecto, bool increase)
        {
            MySqlConnection connection = Connect();
            string sql1 = "", sql2 = "", sql3 = "";

            if (!increase)
            {
                sql1 = "UPDATE categorias SET PuntuacionTotal = PuntuacionTotal - @puntuacionCei WHERE Proyecto = @proyecto AND Categoria = 'creatividad';";
                sql2 = "UPDATE categorias SET PuntuacionTotal = PuntuacionTotal - @puntuacionPdi WHERE Proyecto = @proyecto AND Categoria = 'implementacion';";
                sql3 = "UPDATE categorias SET PuntuacionTotal = PuntuacionTotal - @puntuacionComunicacion WHERE Proyecto = @proyecto AND Categoria = 'comunicacion';";
            }

            if (increase)
            {
                sql1 = "UPDATE categorias SET PuntuacionTotal = PuntuacionTotal + @puntuacionCei WHERE Proyecto = @proyecto AND Categoria = 'creatividad';";
                sql2 = "UPDATE categorias SET PuntuacionTotal = PuntuacionTotal + @puntuacionPdi WHERE Proyecto = @proyecto AND Categoria = 'implementacion';";
                sql3 = "UPDATE categorias SET PuntuacionTotal = PuntuacionTotal + @puntuacionComunicacion WHERE Proyecto = @proyecto AND Categoria = 'comunicacion';";
            }

            MySqlCommand command1 = new MySqlCommand(sql1, connection);
            command1.Parameters.AddWithValue("@puntuacionCei", puntuacionCei);
            command1.Parameters.AddWithValue("@proyecto", proyecto);
            MySqlCommand command2 = new MySqlCommand(sql2, connection);
            command2.Parameters.AddWithValue("@puntuacionPdi", puntuacionPdi);
            command2.Parameters.AddWithValue("@proyecto", proyecto);
            MySqlCommand command3 = new MySqlCommand(sql3, connection);
            command3.Parameters.AddWithValue("@puntuacionComunicacion", puntuacionComunicacion);
            command3.Parameters.AddWithValue("@proyecto", proyecto);


            try
            {
                connection.Open();
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error");
            }
        }

    }
}