using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasknetBackend.Models
{
    public class TaskItem
    {
        public int Id {get; set;}
        public string Title { get; set; } = "New task";
        public bool IsCompleted {get; set;} = false;
        public DateTime CreatedAt {get; set;} = DateTime.Now;
    }
}