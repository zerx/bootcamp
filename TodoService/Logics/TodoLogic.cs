using System;
using System.Data.Entity;
using TodoService.Models;
using System.Web.Http.OData;
using System.Linq;
using TodoService.Interfaces;
using System.Collections.Generic;

namespace TodoService.Logics
{
    public class TodoLogic : ITodo
    {
        private TodoContext db = new TodoContext();
        public IQueryable<Todo> GetAllTodo()
        {
            return db.Todos;
        }

        public Todo GetTodoById(Guid id)
        {
            return db.Todos.Find(id);
        }

        public IQueryable<IGrouping<int, Todo>> GetTodosOrderByCategory()
        {
            return db.Todos.GroupBy(e => e.Category);
        }

        public IEnumerable<Todo> GetTodosByCategory(int categoryId)
        {
            return db.Todos.Where(c => categoryId == c.Category);
        }

        public IEnumerable<Todo> GetFreshTodos()
        {
            return db.Todos.Where(e => e.Status == "Open" || DbFunctions.DiffMinutes(e.ModTime, DateTime.Now) <= 120);
        }

        public void PostTodo(Todo todo)
        {
            todo.Id = Guid.NewGuid();
            todo.ModTime = DateTime.Now;
            db.Todos.Add(todo);
            db.SaveChanges();
        }

        public bool PatchTodo(Guid id, Delta<Todo> todo)
        {
            var temp = db.Todos.Find(id);

            if (temp == null)
            {
                return false;
            }

            temp.ModTime = DateTime.Now;
            todo.Patch(temp);
            db.SaveChanges();

            return true;
        }

        public bool DeleteTodo(Guid id)
        {
            var todo = db.Todos.Find(id);
            if (todo == null)
            {
                return false;
            }

            db.Todos.Remove(todo);
            db.SaveChanges();
            return true;
        }
    }
}
