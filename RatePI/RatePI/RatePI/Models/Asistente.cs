using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatePI.Models
{
    public class Asistente
    {
        public Asistente(int idAsistente, string email, string proyecto, int puntuacionCei, int puntuacionPdi, int puntuacionComunicacion, int idProyecto)
        {
            IdAsistente = idAsistente;
            Email = email;
            Proyecto = proyecto;
            PuntuacionCei = puntuacionCei;
            PuntuacionPdi = puntuacionPdi;
            PuntuacionComunicacion = puntuacionComunicacion;
            IdProyecto = idProyecto;
        }

        public int IdAsistente{ get; set; }
        public string Email { get; set; }
        public string Proyecto { get; set; }
        public int PuntuacionCei { get; set; }
        public int PuntuacionPdi { get; set; }
        public int PuntuacionComunicacion { get; set; }
        public int IdProyecto { get; set; }
    }
}