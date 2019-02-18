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

        static List<Todo> TodoList = new List<Todo>
        {
            new Todo {
            Id = Guid.NewGuid(),
            Name = "Test 01",
            Priority = 1,
            Deadline = new DateTime(1991, 01, 01),
            Description = "test 01",
            Responsible = "test 01",
            Status = "test 01",
            Category = CategoryEnum.BUG,
            ParentId = 1
            },

            new Todo {
            Id = Guid.NewGuid(),
            Name = "Test 02",
            Priority = 2,
            Deadline = new DateTime(1991, 01, 02),
            Description = "test 02",
            Responsible = "test 02",
            Status = "test 02",
            Category = CategoryEnum.BUG,
            ParentId = 2
            },

            new Todo {
            Id = Guid.NewGuid(),
            Name = "Test 03",
            Priority = 3,
            Deadline = new DateTime(1991, 01, 03),
            Description = "test 03",
            Responsible = "test 03",
            Status = "test 03",
            Category = CategoryEnum.BUG,
            ParentId = 3
            }
        };

        private Todo GetTodoById(Guid id)
        {
            var todo = TodoList.Find(item => item.Id == id);
            if (todo != null)
            {
                return todo;
            }
            else
            {
                throw new ArgumentException("Given ID is not found!");
            }
        }

        //GET /api/todo
        public IHttpActionResult GetTodos()
        {
            return Ok(TodoList);
        }

        //GET api/todo/{id}
        public IHttpActionResult GetTodo(Guid id)
        {
            Todo item = GetTodoById(id);

            if(item == null)
            {
                return BadRequest();
            }

            return Ok(item);
        }

        //POST api/todo
        public IHttpActionResult CreateTodo([FromBody] Todo newTodo)
        {
            if(String.IsNullOrEmpty(newTodo.Name))
            {
                return BadRequest();
            }

            TodoList.Add(newTodo);
            return Ok("New Todo added.");
            
        }

        //PATCH /api/todo/{id}
        public IHttpActionResult PatchTodo(Guid id, [FromBody] Todo todo)
        {
            var temp = GetTodoById(id);

            if(temp == null)
            {
                return BadRequest();
            }

            temp.Name = todo.Name;
            temp.Priority = todo.Priority;
            temp.Deadline = todo.Deadline;
            temp.Description = todo.Description;
            temp.Responsible = todo.Responsible;
            temp.Status = todo.Status;
            temp.Category = todo.Category;
            temp.ParentId = todo.ParentId;

            return Ok("Todo updated!");


        }

        //DELETE api/todos/{id}
        public IHttpActionResult DeleteTodo(Guid id)
        {
            Todo item = GetTodoById(id);

            if (item == null)
            {
                return BadRequest();
            }

            TodoList.Remove(GetTodoById(id));
            return Ok("Todo deleted!");
        }
    }
}
