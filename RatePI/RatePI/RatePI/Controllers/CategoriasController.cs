using RatePI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RatePI.Controllers
{
    public class CategoriasController : ApiController
    {
        // GET: api/Categorias
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Categorias/5
        public List<CategoriaDTO> Get(string categoria)
        {
            CategoriasRepository re = new CategoriasRepository();
            List<CategoriaDTO> list = re.RetrieveByCategoria(categoria);
            return list;
        }

        // GET: api/Categorias?
        public List<CategoriaDTO> GetByProyecto(string proyecto)
        {
            CategoriasRepository re = new CategoriasRepository();
            List<CategoriaDTO> list = re.RetrieveByProyecto(proyecto);
            return list;
        }

        // POST: api/Categorias
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categorias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categorias/5
        public void Delete(int id)
        {
        }
    }
}
