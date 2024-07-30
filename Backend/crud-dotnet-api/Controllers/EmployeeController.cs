using crud_dotnet_api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

		[HttpPost("AddEmployee")]
		public async Task<ActionResult> AddEmployee([FromBody] Employee model)
		{
			var data = await _employeeRepository.AddEmployeeAsync(model);
			var dataResult = new DataResult<Employee>(0, "Thanh Cong", data);
			return Ok(dataResult);
		}


		[HttpGet("GetListEmployeeList")]
		public async Task<ActionResult> GetListEmployeeList()
		{
			var employeList = await _employeeRepository.GetAllEmployeeAsync();
			return Ok(employeList);
		}


		[HttpGet("{id}")]
		public async Task<ActionResult> GetEmployeeById([FromRoute] int id)
		{
			var employee = await _employeeRepository.GetEmployeeById(id);

			return Ok(employee);
		}



		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee model )
		{
			var data = await _employeeRepository.UpdateEmployee(id, model);
			var dataResult = new DataResult<Employee>(0, "Thanh Cong", data);

			return Ok(dataResult);
		}


		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteEmployee([FromRoute] int id)
		{
			await _employeeRepository.DeleteEmployee(id);
			var dataResult = new DataResult<Employee>(0, "Thanh Cong", null);
			return Ok(dataResult);

		}

	}

	 
}
