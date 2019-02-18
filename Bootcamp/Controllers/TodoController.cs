using Bootcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Bootcamp.Controllers
{
    public class TodoController : ApiController
    {

        private TodoContext _db = new TodoContext();

        //GET /api/todo
        public IHttpActionResult GetTodos()
        {
            return Ok(_db.Todos);
        }

        //GET api/todo/{id}
        public IHttpActionResult GetTodo(Guid id)
        {
            var todo = _db.Todos.Find(id);

            if (todo == null)
            {
                return BadRequest();
            }

            return Ok(todo);
        }

        //POST api/todo
        public IHttpActionResult PostTodo([FromBody] Todo newTodo)
        {
            newTodo.Id = Guid.NewGuid();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Todos.Add(newTodo);
            _db.SaveChanges();

            return Ok("Todo added.");

        }

        //PATCH /api/todo/{id}
        public IHttpActionResult PatchTodo(Guid id, [FromBody] Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            todo.Id = id;
            _db.Entry(_db.Todos.Find(id)).CurrentValues.SetValues(todo);
            _db.SaveChanges();

            return Ok("Todo updated.");


        }

        //DELETE api/todos/{id}
        public IHttpActionResult DeleteTodo(Guid id)
        {
            var todo = _db.Todos.Find(id);
            if (todo is null)
            {
                return NotFound();
            }

            _db.Todos.Remove(todo);
            _db.SaveChanges();

            return Ok("Todo deleted.");
        }
    }
}
