using back_end_alpha.Dto;
using back_end_alpha.Interfaces;
using back_end_alpha.Models;
using back_end_alpha.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace back_end_alpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
	{
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
		{
            _taskRepository = taskRepository;
		}


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Models.Task>))]
        public IActionResult GetTasks()
        {
            var tasks = _taskRepository.GetTasks();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tasks);
        }

        [HttpGet("{TaskId}")]
        [ProducesResponseType(200, Type = typeof(Models.Task))]
        [ProducesResponseType(400)]
        public IActionResult GetTaskById(int TaskId)
        {
            var task = _taskRepository.GetTaskById(TaskId);

            if (task == null)
                return StatusCode(500, "There is no task with this Id");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(task);
        }


        [HttpGet("Client/{ClientId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Models.Task>))]
        [ProducesResponseType(400)]
        public IActionResult GetTasksByClientId(int ClientId)
        {
            var tasks = _taskRepository.GetTasksByClientId(ClientId);

            if (tasks == null)
                return StatusCode(500, "There is no task with this client Id");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tasks);
        }

        [HttpGet("Employee/{EmployeeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Models.Task>))]
        [ProducesResponseType(400)]
        public IActionResult GetTasksByEmployeeId(int EmployeeId)
        {
            var tasks = _taskRepository.GetTasksByEmployeeId(EmployeeId);

            if (tasks == null)
                return StatusCode(500, "There is no task with this employee Id");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tasks);
        }

        [HttpGet("TaskDone")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Models.Task>))]
        [ProducesResponseType(400)]
        public IActionResult GetTasksDone()
        {
            var tasks = _taskRepository.GetTasksDone();

            if (tasks == null)
                return StatusCode(500, "There is no task with this employee Id");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tasks);
        }

        [HttpGet("TaskNotDone")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Models.Task>))]
        [ProducesResponseType(400)]
        public IActionResult GetTasksNotDone()
        {
            var tasks = _taskRepository.GetTasksNotDone();

            if (tasks == null)
                return StatusCode(500, "There is no task with this employee Id");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tasks);
        }


        [HttpDelete("{TaskId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTask(int TaskId)
        {
            try
            {

                var task = _taskRepository.GetTaskById(TaskId);
                if (task == null)
                    return StatusCode(500, "There is no task with this Id");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (!_taskRepository.DeleteTask(task))
                    return StatusCode(500, "Something went Wrong with the Db");

                return Ok("Successfully Delete it");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong in the Api");
            }

        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTask([FromBody] TaskDto Taskcreate)
        {
            try
            {
                if (Taskcreate == null)
                    return BadRequest();


                if (!ModelState.IsValid)
                    return BadRequest(ModelState);


                var status = _taskRepository.CreateTask(Taskcreate.Title, Taskcreate.ClientId, Taskcreate.EmployeeId);

                if (status == 500)
                    return StatusCode(500, "The Client with this id is not found");

                if (status == 501)
                    return StatusCode(500, "The Employee with this id is not found");


                return Ok("Successfully Create it");
            }
            catch (DbUpdateException ex)
            {
                
                return StatusCode(500, "Something went wrong in the Db or api");
            }

        }





        [HttpPut("{TaskId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTaskState(int TaskId)
        {
            try
            {

                var task = _taskRepository.GetTaskById(TaskId);
                if (task == null)
                    return StatusCode(500, "There is no task with this Id");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (!_taskRepository.UpdateTaskState(task))
                    return StatusCode(500, "Something went Wrong with the Db");

                return Ok("Successfully Delete it");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong in the Api");
            }

        }

    }
}

