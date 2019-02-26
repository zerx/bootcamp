using System;
using System.Web.Http;
using System.Web.Http.OData;
using TodoService.Logics;
using TodoService.Models;

namespace Bootcamp.Controllers
{
    public class TodoController : ApiController
    {

        private TodoLogic todoLogic = new TodoLogic();

        //GET /api/todo
        public IHttpActionResult GetTodos()
        {
            return Ok(todoLogic.GetAllTodo());
        }

        //GET api/todo/{id}
        public IHttpActionResult GetTodo(Guid id)
        {
            return Ok(todoLogic.GetTodoById(id));
        }
        

        [HttpGet]
        [Route("api/todo/category")]
        public IHttpActionResult GetTodosOrderByCategory()
        {
            return Ok(todoLogic.GetTodosOrderByCategory());
        }

        [HttpGet]
        [Route("api/todo/category/{categoryId}")]
        public IHttpActionResult GetTodosByCategory(int categoryId)
        {
            return Ok(todoLogic.GetTodosByCategory(categoryId));
        }

        [HttpGet]
        [Route("api/todo/fresh")]
        public IHttpActionResult GetFreshTodos()
        {
            return Ok(todoLogic.GetFreshTodos());
        }

        //POST api/todo
        public IHttpActionResult PostTodo([FromBody] Todo newTodo)
        {
            todoLogic.PostTodo(newTodo);
            return Ok("Todo added.");

        }

        //PATCH /api/todo/{id}
        public IHttpActionResult PatchTodo(Guid id, [FromBody] Delta<Todo> todo)
        {
            bool isPatched = todoLogic.PatchTodo(id, todo);

            return isPatched ? (IHttpActionResult)Ok("Todo updated.") : NotFound();

        }

        //DELETE api/todo/{id}
        public IHttpActionResult DeleteTodo(Guid id)
        {

            bool isDeleted = todoLogic.DeleteTodo(id);
            return isDeleted ? (IHttpActionResult)Ok("Todo deleted.") : NotFound();
        }
    }
}
