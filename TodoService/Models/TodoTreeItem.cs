using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoService.Models
{
    public class TodoTreeItem
    {
        public Todo Todo { get; set; }
        public List<TodoTreeItem> Children { get; set; }

        public TodoTreeItem(Todo todo)
        {
            this.Todo = todo;
            this.Children = new List<TodoTreeItem>();
        }
    }
}