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
                    int votaciones = VotacionesPorProyecto(proyecto);
                    double media = puntuacion / votaciones;

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

            }
        }

        internal void UpdateCategorias()
        {

        }

    }
}