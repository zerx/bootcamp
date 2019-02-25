using System;
using System.Linq;
using System.Web.Http.OData;
using TodoService.Models;

namespace TodoService.Interfaces
{
    public interface ITodo
    {
        IQueryable<Todo> GetAllTodo();
        Todo GetTodoById(Guid id);
        void PostTodo(Todo todo);
        bool PatchTodo(Guid id, Delta<Todo> todo);
        bool DeleteTodo(Guid id);
    }
}
