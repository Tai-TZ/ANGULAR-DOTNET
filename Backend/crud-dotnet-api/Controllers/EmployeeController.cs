using crud_dotnet_api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_dotnet_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly EmployeeRepository _employeeRepository;

		public EmployeeController(EmployeeRepository employeeRepository)
		{
			 _employeeRepository = employeeRepository;
		}

		[HttpPost]
		public async Task<ActionResult> AddEmployee([FromBody] Employee model)
		{
			await _employeeRepository.AddEmployee(model);
			return Ok();
		}
	}

	 
}
