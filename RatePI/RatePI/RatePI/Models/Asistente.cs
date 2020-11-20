using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatePI.Models
{
    public class Asistente
    {
        public Asistente(int idAsistente, string email, string proyecto, string categoria, int puntuacion, int idProyecto)
        {
            IdAsistente = idAsistente;
            Email = email;
            Proyecto = proyecto;
            Categoria = categoria;
            Puntuacion = puntuacion;
            IdProyecto = idProyecto;
        }

        public int IdAsistente{ get; set; }
        public string Email { get; set; }
        public string Proyecto { get; set; }
        public string Categoria { get; set; }
        public int Puntuacion { get; set; }
        public int IdProyecto { get; set; }
    }
}