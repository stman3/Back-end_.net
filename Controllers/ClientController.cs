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
    public class ClientController : Controller
	{
		private readonly IClientRepository _clientRepository;
		public ClientController(IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}

		[HttpGet]
		[ProducesResponseType(200,Type = typeof(IEnumerable<Client>))]
		public IActionResult GetClients()
		{
            var clients = _clientRepository.GetClients();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(clients);
		}

		[HttpGet("{ClientId}")]
		[ProducesResponseType(200,Type = typeof(Client))]
        [ProducesResponseType(400)]
		public IActionResult GetClientById(int ClientId)
		{
			var client = _clientRepository.GetClientById(ClientId);

            if (client == null)
                return StatusCode(500, "There is no Client with this Id");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(client);
        }

        [HttpGet("Employe/{EmploeeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Client>))]
		public IActionResult GetClientsByEmployeeId(int EmploeeId)
		{
            var client = _clientRepository.GetClientsByEmployeeId(EmploeeId);

            if (client == null)
                return StatusCode(500, "There is no client for this EmploeeId");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
		public IActionResult CreateClient([FromBody] ClientDto clientcreate)
		{
			try
			{
				if (CreateClient == null)
					return BadRequest();

				if (clientcreate.PhoneNumber.Length != 10)
					return StatusCode(500, "The phone number should be 10");
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				if (!_clientRepository.CreateClient(
					clientcreate.NationalIdentity,
					clientcreate.FirstName,
					clientcreate.LastName,
					clientcreate.PhoneNumber,
					clientcreate.State,
					clientcreate.Note,
					clientcreate.EmployeeId))
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

                    return StatusCode(500, "there is other Clinet with the same National Identity");
                }


                return StatusCode(500, "Something went wrong in the Db or api");
            }

        }

        [HttpDelete("{ClientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteClinet(int ClientId)
        {
            try
            {
                var client = _clientRepository.GetClientById(ClientId);
                if (client == null)
                    return StatusCode(500, "There is no client with this Id");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (!_clientRepository.DeleteClient(client))
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

