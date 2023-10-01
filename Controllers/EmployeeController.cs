using back_end_alpha.Dto;
using back_end_alpha.Interfaces;
using back_end_alpha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace back_end_alpha.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : Controller
	{

		private readonly IEmployeeRepository _employeeRepository;
		public EmployeeController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		[HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
		public IActionResult GetEmployees()
		{
			var Employees = _employeeRepository.GetEmployees();
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(Employees);
		}

		[HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEployee([FromBody] EmployeeDto employeeCreate)
		{
			try
			{
                if (employeeCreate == null)
                    return BadRequest();




                if (employeeCreate.PhoneNumber.Length != 10)
                {
                    return StatusCode(500, "The Phone number should be 10");
                }
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);


                if (!_employeeRepository.CreateEmployee(
                    employeeCreate.NationalIdentity,
                    employeeCreate.FirstName,
                    employeeCreate.LastName,
                    employeeCreate.PhoneNumber,
                    employeeCreate.Role,
                    employeeCreate.BirthDate,
                    employeeCreate.State,
                    employeeCreate.Salary))
                {
                    ModelState.AddModelError("", "Something went wrong while saveing");
                    return StatusCode(500, ModelState);
                }

                return Ok("Successfully created");
            }
            catch (DbUpdateException ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;

         
                if (sqlException?.Number == 2601 || sqlException?.Number == 2627)
                {
      
                    return StatusCode(500, "there is other employee with the same National Identity");
                }


                return StatusCode(500, "Something went wrong in the Api");
            }


        }

        [HttpDelete("{EmployeeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEmployee(int EmployeeId)
        {
            try
            {
                var employee = _employeeRepository.GetEmployeeId(EmployeeId);
                if (employee == null)
                    return StatusCode(500, "There is no Employee with this Id");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (!_employeeRepository.DeleteEmployee(employee))
                    return StatusCode(500, "Something went Wrong with the Db");

                return Ok("Successfully Delete it");

            }
            catch(Exception ex)
            {
                return StatusCode(500, "Something went wrong in the Api");
            }

        }


        [HttpGet("{EmployeeId}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        public IActionResult GetEmployeeId(int EmployeeId)
        {
            var employee = _employeeRepository.GetEmployeeId(EmployeeId);

            if (employee == null)
                return StatusCode(500, "There is no Employee with this Id");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(employee);

        }

        [HttpGet("NationalIdentity/{NationalIdentity}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        public IActionResult GetEmployeeByNationalIdentity(String NationalIdentity)
        {
            var employee = _employeeRepository.GetEmployeeByNationalIdentity(NationalIdentity);

            if (employee == null)
                return StatusCode(500, "There is no Employee with this National Identity");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(employee);

        }

    }
}

