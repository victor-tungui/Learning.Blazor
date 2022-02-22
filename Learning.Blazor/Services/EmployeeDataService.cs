using Learning.Blazor.Shared;
using System.Text.Json;

namespace Learning.Blazor.Services;

public class EmployeeDataService : IEmployeeDataService
{
	private readonly HttpClient _httpClient;

	public EmployeeDataService(HttpClient httpClient)
	{
		this._httpClient = httpClient;
	}

	public Task<Employee> AddEmployee(Employee employee)
	{
		throw new NotImplementedException();
	}

	public Task DeleteEmployee(int employeeId)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Employee>> GetAllEmployees()
	{
		//try
		//{
		Stream stream = await _httpClient.GetStreamAsync($"api/employee");

		IEnumerable<Employee> employees = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

		return employees;
		//}
		//catch (Exception ex)
		//{
		//	string message = ex.Message;
		//}

		//return null;
	}

	public async Task<Employee> GetEmployeeDetails(int employeeId)
	{
		Stream stream = await _httpClient.GetStreamAsync($"api/employee/{employeeId}");

		Employee employee = await JsonSerializer.DeserializeAsync<Employee>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

		return employee;
	}

	public Task UpdateEmployee(Employee employee)
	{
		throw new NotImplementedException();
	}
}

