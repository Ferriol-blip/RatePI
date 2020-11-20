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
            categoria = categoria;
            Puntuacion = puntuacion;
            Proyecto = proyecto;
        }

        public int IdCategoria { get; set; }
        public int IdProyecto { get; set; }
        public string categoria { get; set; }
        public int Puntuacion { get; set; }
        public string Proyecto { get; set; }
    }

    public class CategoriaDTO
    {
        public CategoriaDTO(string proyecto, string cat, double puntuacion)
        {
            Proyecto = proyecto;
            categoria = cat;
            Puntuacion = puntuacion;
        }

        public string Proyecto { get; set; }
        public string categoria { get; set; }
        public double Puntuacion { get; set; }
    }

    public class CategoriaMedia
    {
        public CategoriaMedia(string proyecto, string cat, double puntuacion)
        {
            Proyecto = proyecto;
            categoria = cat;
            Media = puntuacion;
        }

        public string Proyecto { get; set; }
        public string categoria { get; set; }
        public double Media { get; set; }
    }

}