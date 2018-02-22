using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using taskmanager_api.Models;

namespace taskmanager_api.Controllers
{
    public class CategoryController : ApiController
    {
        taskmanagerdb tmdb = new taskmanagerdb();
        // GET api/Category
        [SwaggerOperation("GetAll")]
        public IEnumerable<categoria> Get()
        {
            return tmdb.categoria.ToList();
        }

        // GET api/Category/{id}
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(int id)
        {
            var cat = tmdb.categoria.FirstOrDefault((c) => c.id == id);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }

        // POST api/Category
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public IHttpActionResult Post([FromBody] dynamic body)
        {
            if (body.nome != null)
            {
                categoria last = tmdb.categoria.ToList().LastOrDefault();
                tmdb.categoria.Add(new categoria
                {
                    id = (last == null) ? 0 : last.id + 1,
                    categoria1 = (string)body.nome
                });
                tmdb.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        // PUT api/Category/{id}
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Put(int id, [FromBody] dynamic body)
        {
            categoria c = tmdb.categoria.Find(id);
            if (body.categoria1 != null)
            {
                c.categoria1 = (string)body.nome;
            }
            tmdb.SaveChanges();
            return Ok();
        }

        // DELETE api/Category/{id}
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Delete(int id)
        {
            var cat = tmdb.categoria.FirstOrDefault((c) => c.id == id);
            if (cat != null)
            {
                tmdb.categoria.Remove(cat);
                tmdb.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
