using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using taskmanager_api.Models;
using Swashbuckle.Swagger.Annotations;

namespace taskmanager_api.Controllers
{
    public class TaskmanagerController : ApiController
    {
        taskmanagerdb tmdb = new taskmanagerdb();
        // GET: api/Taskmanager
        public List<tarefas> Get()
        {
            return tmdb.tarefas.ToList();
        }

        // Post: api/Taskmanager
        [HttpPost]
        public void DeleteById(int id)
        {
            tmdb.tarefas.Remove(tmdb.tarefas.Find(id));
            tmdb.SaveChanges();
        }
        /*
        // POST: api/Taskmanager
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Taskmanager/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Taskmanager/5
        public void Delete(int id)
        {
        }
        */
    }
}
