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
    public class UserController : ApiController
    {
        taskmanagerdb tmdb = new taskmanagerdb();
        
        // GET api/User
        [SwaggerOperation("GetAll")]
        public IHttpActionResult Get(string email, string senha)
        {
            usuarios user = tmdb.usuarios.Where(u => u.email == email).SingleOrDefault();
            if (user != null && user.senha == senha)
            {
                return Ok(user);
            }
            return NotFound();
        }
        
        /*
        // GET api/User/{id}
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(int id)
        {
            var user = tmdb.usuarios.FirstOrDefault((u) => u.id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        */

        // POST api/User
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public IHttpActionResult Post([FromBody] dynamic body)
        {
            string email = (string)body.email;
            var exist = tmdb.usuarios.Where(u => u.email == email).ToList();
            usuarios last = tmdb.usuarios.ToList().LastOrDefault();
            if (body.nome != null && exist.Count == 0)
            {
                Random rnd = new Random();
                int rdnid = rnd.Next(100, 201);
                usuarios user = new usuarios()
                {
                    id = (last == null) ? rdnid : last.id + rdnid,
                    nome = (string)body.nome,
                    email = email,
                    senha = (string)body.senha,
                    foto = (string)body.foto,
                };
                tmdb.usuarios.Add(user);
                tmdb.SaveChanges();
                return Ok(user);
            }
            return NotFound();
        }
        /*
        // PUT api/User/{id}
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Put(int id, [FromBody] dynamic body)
        {
            usuarios c = tmdb.usuarios.Find(id);
            if (body.nome != null)
            {
                c.nome = (string)body.nome;
            }
            tmdb.SaveChanges();
            return Ok();
        }

        // DELETE api/User/{id}
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Delete(int id)
        {
            var cat = tmdb.usuarios.FirstOrDefault((c) => c.id == id);
            if (cat != null)
            {
                tmdb.usuarios.Remove(cat);
                tmdb.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        */
    }
}
