using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatePI.Models
{
    public class Proyecto
    {
        public Proyecto(int idProyecto, string nombre, string descripcion, string cicloFormativo)
        {
            IdProyecto = idProyecto;
            Nombre = nombre;
            Descripcion = descripcion;
            CicloFormativo = cicloFormativo;
        }

        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CicloFormativo { get; set; }
    }

    public class ProyectoDTO
    {
        public ProyectoDTO(string nombre, string descripcion, string cicloFormativo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            CicloFormativo = cicloFormativo;
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CicloFormativo { get; set; }
    }
}