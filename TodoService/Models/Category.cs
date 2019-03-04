using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoService.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [StringLength(50)]
        public String Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModified { get; set; }
        public List<Todo> Todos { get; set; }
    }
}