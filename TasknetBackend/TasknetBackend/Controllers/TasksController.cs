using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasknetBackend.Models;

namespace TasknetBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskContext _taskContext;
        public TasksController(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            if (_taskContext.Tasks == null)
            {
                return NotFound();
            }
            return await _taskContext.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            if (_taskContext.Tasks == null)
            {
                return NotFound();
            }
            var task = await _taskContext.Tasks.FindAsync(id);
            if (task is null)
            {
                return NotFound();
            }
            return task;
        }
    }
}