using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using taskmanager_api.Models;

namespace taskmanager_api.Controllers
{
    public class TaskmanagerController : ApiController
    {
        taskmanagerdb tmdb = new taskmanagerdb();
        // GET api/Taskmanager
        [SwaggerOperation("GetAll")]
        public IEnumerable<tarefas> Get()
        {
            return tmdb.tarefas.ToList();
        }

        // GET api/Taskmanager/{id}
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(int id)
        {
            var task = tmdb.tarefas.FirstOrDefault((t) => t.id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST api/Taskmanager
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public IHttpActionResult Post([FromBody] dynamic body)
        {
            tmdb.tarefas.Add(new tarefas
            {
                id = tmdb.tarefas.ToList().Last().id + 1,
                nome = (string)body.nome,
                categoria = (string)body.categoria,
                feito = false
            });
            tmdb.SaveChanges();
            return Ok();
        }

        // PUT api/Taskmanager/{id}
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Put(int id, [FromBody] dynamic body)
        {
            tarefas t = tmdb.tarefas.Find(id);
            t.nome = (string)body.nome;
            t.categoria = (string)body.categoria;
            t.feito = (bool)body.feito;
            tmdb.SaveChanges();
            return Ok();
        }

        // DELETE api/Taskmanager/{id}
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Delete(int id)
        {
            var task = tmdb.tarefas.FirstOrDefault((t) => t.id == id);
            if (task != null)
            {
                tmdb.tarefas.Remove(task);
                tmdb.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
