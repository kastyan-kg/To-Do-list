using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class TaskEntry
    {
        public int ID { get; set; }
        [StringLength(45, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [StringLength(200, MinimumLength = 5)]
        [Required]
        public string Description { get; set; }
        [Display(Name = "Dead line")]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
        [Display(Name = "Done")]
        public bool IsFinished { get; set; }
    }
}
