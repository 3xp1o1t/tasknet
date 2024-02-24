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
    [Route("api/tasks")]
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

        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
        {
            _taskContext.Tasks.Add(task);
            await _taskContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new {id = task.Id}, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskItem>> PutTask(int id, TaskItem task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _taskContext.Entry(task).State = EntityState.Modified;

            try
            {
                await _taskContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!TaskExists(id)) {return NotFound();}
                else {throw;}
            }

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return (_taskContext.Tasks?.Any(task => task.Id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskItem>> DeleteTask(int id)
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

            _taskContext.Tasks.Remove(task);
            await _taskContext.SaveChangesAsync();
            return NoContent();
        }

    }
}