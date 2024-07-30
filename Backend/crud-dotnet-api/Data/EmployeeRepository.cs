using Microsoft.EntityFrameworkCore;

namespace crud_dotnet_api.Data
{
	public class EmployeeRepository
	{
		private readonly AppDbContext _appDbContext;


		public EmployeeRepository(AppDbContext appDbContext) {

			 _appDbContext = appDbContext;
		}
	
	
		public async Task<Employee> AddEmployeeAsync(Employee employee)
		{
			await _appDbContext.Set<Employee>().AddAsync(employee);
			await _appDbContext.SaveChangesAsync();
			return await _appDbContext.Employees.FindAsync(employee.id);
		}
	

		public async Task<List<Employee>> GetAllEmployeeAsync()
		{
			return await _appDbContext.Employees.ToListAsync();
		}
	

		public async Task<Employee> GetEmployeeById(int id)
		{
			return await _appDbContext.Employees.FindAsync(id);
		}


		public async Task<Employee> UpdateEmployee(int id, Employee model)
		{
			var employee = await _appDbContext.Employees.FindAsync(id);

			if (employee == null)
			{
				throw new Exception("Employee not found");
			}
			else
			{
				employee.Name = model.Name;
				employee.Email = model.Email;
				employee.Phone = model.Phone;
				employee.Age = model.Age;
				employee.Salary = model.Salary;
				await _appDbContext.SaveChangesAsync();
			}

			return employee;

		}


		public async Task DeleteEmployee(int id)
		{
			var employee = await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
				throw new Exception("Employee not found");
            } 

			_appDbContext.Employees.Remove(employee);
			await _appDbContext.SaveChangesAsync();
			  
        }
	}
}
