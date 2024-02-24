using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasknetBackend.Models
{
    public class Task
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public bool IsCompleted {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
    }
}