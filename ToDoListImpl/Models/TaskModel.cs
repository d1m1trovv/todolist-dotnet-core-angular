using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListImpl.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Tittle must not be longer than 200 chars")]
        public string Title { get; set; }

        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
