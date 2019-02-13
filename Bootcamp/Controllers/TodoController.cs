using Bootcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Bootcamp.Controllers
{
    public class TodoController : ApiController
    {

        static List<Todo> TodoList = new List<Todo>
        {
            new Todo("Test 01", 2, new DateTime(1991,01,01),"test 01","test 01","test 01", CategoryEnum.BUG, 1),
            new Todo("Test 02", 3, new DateTime(1991,01,02),"test 02","test 02","test 02", CategoryEnum.TASK, 2),
            new Todo("Test 03", 4, new DateTime(1991,01,03),"test 03","test 03","test 03", CategoryEnum.EPIC, 3),
        };

        //GET /api/todo
        public List<Todo> GetTodos()
        {
            return TodoList;
        }

        //GET api/todo/{id}
        public Todo GetTodo(int id)
        {
            return TodoList.ElementAt(id);
        }

        //POST api/todo
        public void CreateTodo([FromBody] Todo todo)
        {
            TodoList.Add(todo);
        }

        //POST /api/todo/{id}
        public void UpdateTodo(int id, [FromBody] Todo todo)
        {
            var temp = TodoList.ElementAt(id);
            temp.Name = todo.Name;
        }

        //DELETE api/todos/{id}
        public void DeleteTodo(int id)
        {
            TodoList.RemoveAt(id);
        }
    }
}
