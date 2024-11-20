using lesson3.Models;
using lesson3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lesson3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTasksByProjectId(int id)
        {
            var tasks = _taskService.GetTasksByProjectId(id);
            if (tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetTasksId(int id)
        //{
        //    var tasks = _taskService.GetTaskById(id);
        //    if (tasks == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(tasks);
        //}

        [HttpPost]
        public IActionResult Create(Tasks task)
        {
            _taskService.AddTask(task);
            return CreatedAtAction(nameof(GetAllTasks), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Tasks task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _taskService.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
            return NoContent();
        }


    }

  

}
