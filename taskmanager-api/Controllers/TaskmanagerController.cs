using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using taskmanager_api.Models;

namespace taskmanager_api.Controllers
{
    [Route("api/Taskmanager")]
    public class TaskmanagerController : ApiController
    {
        taskmanagerdb tmdb = new taskmanagerdb();

        public IEnumerable<tarefas> GetAll()
        {
            return tmdb.tarefas.ToList();
        }

        public IHttpActionResult GatTask(int id)
        {
            tarefas tarefa = tmdb.tarefas.Find(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }
    }
}
