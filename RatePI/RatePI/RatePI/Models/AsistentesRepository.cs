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
            MySqlConnection connection = Connect();
            
        }

    }
}