using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoService.Models
{
    public class TodoTree
    {
        public Todo Todo { get; set; }
        public List<TodoTree> Children { get; set; }
    }
}