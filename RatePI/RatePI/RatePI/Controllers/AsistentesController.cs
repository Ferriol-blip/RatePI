using RatePI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RatePI.Controllers
{
    public class AsistentesController : ApiController
    {
        // GET: api/Asistentes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Asistentes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Asistentes
        public void Post([FromBody] Asistente asist)
        {
            AsistentesRepository re = new AsistentesRepository();
            re.Save(asist);
        }

        // PUT: api/Asistentes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Asistentes/5
        public void Delete(string email)
        {
            AsistentesRepository re = new AsistentesRepository();
            re.DeleteByEmail(email);

        }
    }
}
