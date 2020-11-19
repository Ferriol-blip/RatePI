using RatePI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RatePI.Controllers
{
    public class ProyectosController : ApiController
    {
        // GET: api/Proyectos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Proyectos/5
        public List<Proyecto> Get(string ciclo)
        {
            ProyectosRepository re = new ProyectosRepository();
            List<Proyecto> list = re.RetrieveByCiclo(ciclo);
            return list;
        }

        // GET: api/Proyectos?ciclo=ciclo&categoria=categoria&puntuacion=puntuacion
        public List<ProyectoDTO> GetDTO(string ciclo, int puntuacion)
        {
            ProyectosRepository re = new ProyectosRepository();
            List<ProyectoDTO> list = re.RetrieveByCicloAndPunt(ciclo, puntuacion);
            return list;
        }
        [Authorize(Roles = "admin")]
        // POST: api/Proyectos
        public void Post([FromBody]Proyecto pro)
        {
            ProyectosRepository repro = new ProyectosRepository();
            repro.Save(pro);
        }

        // PUT: api/Proyectos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Proyectos/5
        public void Delete(int id)
        {
        }
    }
}
