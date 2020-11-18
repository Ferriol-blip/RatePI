using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatePI.Models
{
    public class Categoria
    {
        public Categoria(int idCategoria, int idProyecto, string categoria, int puntuacion, string proyecto)
        {
            IdCategoria = idCategoria;
            IdProyecto = idProyecto;
            Cat = categoria;
            Puntuacion = puntuacion;
            Proyecto = proyecto;
        }

        public int IdCategoria { get; set; }
        public int IdProyecto { get; set; }
        public string Cat { get; set; }
        public int Puntuacion { get; set; }
        public string Proyecto { get; set; }
    }

    public class CategoriaDTO
    {
        public CategoriaDTO(string proyecto, string cat, double puntuacionMedia)
        {
            Proyecto = proyecto;
            Cat = cat;
            PuntuacionMedia = puntuacionMedia;
        }

        public string Proyecto { get; set; }
        public string Cat { get; set; }
        public double PuntuacionMedia { get; set; }
    }

}