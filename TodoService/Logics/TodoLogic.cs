﻿using System;
using System.Data.Entity;
using TodoService.Models;
using System.Web.Http.OData;
using System.Linq;
using TodoService.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Configuration;

namespace TodoService.Logics
{
    public class TodoLogic : ITodo
    {
        //int minutesBefore = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MinutesBefore"]);
        private int minutesBefore = 120;

        public TodoLogic()
        {
            int.TryParse(ConfigurationManager.AppSettings["MinutesBefore"], out minutesBefore);
        }

        public IEnumerable<TodoTreeItem> GetTodoTree()
        {
            var todoTree = new List<TodoTreeItem>();
            var rootTodos = new List<TodoTreeItem>();

            foreach (var dbtodo in db.Todos)
            {
                if (dbtodo.ParentId == Guid.Empty)
                {
                    var newTodoTreeItem = new TodoTreeItem(dbtodo);
                    todoTree.Add(newTodoTreeItem);
                    rootTodos.Add(newTodoTreeItem);
                }
            }

            SetChildren(todoTree, rootTodos);

            return todoTree;
        }

        public bool SetChildren(List<TodoTreeItem> todoTree, List<TodoTreeItem> actualTreeLevel)
        {
            var newTreeLevel = new List<TodoTreeItem>();

            foreach (var todo in actualTreeLevel)
            {
                foreach (var dbtodo in db.Todos)
                {
                    if (todo.Todo.Id == dbtodo.ParentId)
                    {
                        var newTodoTreeItem = new TodoTreeItem(dbtodo);
                        newTreeLevel.Add(newTodoTreeItem);
                        todo.Children.Add(newTodoTreeItem);
                    }
                }
            }

            if (newTreeLevel.Count == 0) {
                return false;
            }

            SetChildren(todoTree, newTreeLevel);
            return true;
        }


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
            return db.Todos.Where(e => e.Status == "Open" || DbFunctions.DiffMinutes(e.ModTime, DateTime.Now) <= minutesBefore);
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
