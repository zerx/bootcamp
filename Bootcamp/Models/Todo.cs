using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bootcamp.Models;

namespace Bootcamp.Models
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        [Required]
        public int Priority { get; set; }
        [StringLength(30)]
        public string Responsible { get; set; }
        public DateTime Deadline { get; set; }
        [StringLength(30)]
        public string Status { get; set; }
        public CategoryEnum Category { get; set; }
        [Range(1, 3)]
        public int ParentId { get; set; }
    }
}