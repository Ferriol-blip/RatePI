using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatePI.Models
{
    public class ProyectosRepository : Interface
    {
        internal List<Proyecto> RetrieveByCiclo(string ciclo)
        {
            MySqlConnection connection = Connect();
            string sql = "SELECT * FROM proyectosintegrados WHERE CicloFormativo='" + ciclo + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);

            List<Proyecto> list = new List<Proyecto>();
            Proyecto obj;
            try
            {
                connection.Open();
                MySqlDataReader re = command.ExecuteReader();
                while (re.Read())
                {
                    obj = new Proyecto(re.GetInt16(0), re.GetString(1), re.GetString(2), re.GetString(3));
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

        internal List<ProyectoDTO> RetrieveByCicloAndPunt(string ciclo, string categoria, int puntuacion)
        {
            MySqlConnection connection = Connect();
            string sql = "SELECT `proyectosintegrados`.`Nombre`, `proyectosintegrados`.`Descripcion`, `proyectosintegrados`.`CicloFormativo` " +
            "FROM `proyectosintegrados`, `categorias` " +
            "WHERE `proyectosintegrados`.`CicloFormativo` = @ciclo AND `categorias`.`Categoria` = @categoria AND `categorias`.`PuntuacionTotal` = @puntuacion;";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ciclo", ciclo);
            command.Parameters.AddWithValue("@categoria", categoria);
            command.Parameters.AddWithValue("@puntuacion", puntuacion);
            List<ProyectoDTO> list = new List<ProyectoDTO>();
            ProyectoDTO obj;
            try
            {
                connection.Open();
                MySqlDataReader re = command.ExecuteReader();
                while (re.Read())
                {
                    obj = new ProyectoDTO(re.GetString(0), re.GetString(1), re.GetString(2));
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


        internal void Save(Proyecto pro)
        {
            MySqlConnection connection = Connect();
            //Se isnerta un proyecto
            string sql = "INSERT INTO `mydb`.`PROYECTOSINTEGRADOS` (`Nombre`, `Descripcion`, `CicloFormativo`) VALUES(@nombre, @desc, @ciclo)";           
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@nombre", pro.Nombre);
            command.Parameters.AddWithValue("@desc", pro.Descripcion);
            command.Parameters.AddWithValue("@ciclo", pro.CicloFormativo);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                
            }
            //Se inserta las categorias asociadas a cada proyecto
            int id = RetrieveIdByProyect(pro.Nombre); //optenemos el id del proyecto que se acaba de insertar
            CategoriasRepository reCat = new CategoriasRepository();
            reCat.InsertCategorias(id, pro.Nombre);
        }

        public static int RetrieveIdByProyect(string proyecto)
        {
            MySqlConnection connection = Connect();
            string sql = "SELECT idProyecto FROM proyectosintegrados WHERE Nombre = '" + proyecto + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            int id = 0;
            try
            {
                connection.Open();
                MySqlDataReader re = command.ExecuteReader();

                while (re.Read())
                {
                    id = re.GetInt16(0);
                }
                return id;
            }
            catch (MySqlException ex)
            {
                return 0;
            }
        }

    }

}