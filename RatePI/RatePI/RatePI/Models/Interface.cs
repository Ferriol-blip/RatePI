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
    }
}