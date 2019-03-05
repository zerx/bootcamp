using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoService.Models.Procedures
{
    public class TodoResponsible
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
        public Guid CategoryId { get; set; }
        public Guid ParentId { get; set; }
        public DateTime ModTime { get; set; }
        public Boolean Deleted { get; set; }
    }
}