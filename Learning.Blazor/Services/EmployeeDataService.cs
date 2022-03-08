using Learning.Blazor.Shared;
using System.Text;
using System.Text.Json;

namespace Learning.Blazor.Services;

public class EmployeeDataService : IEmployeeDataService
{
	private readonly HttpClient _httpClient;

	public EmployeeDataService(HttpClient httpClient)
	{
		this._httpClient = httpClient;
	}

	public async Task<Employee> AddEmployee(Employee employee)
	{
		var employeeJson = JsonSerializer.Serialize(employee);

		var content = new StringContent(employeeJson, Encoding.UTF8, "application/json");

		var response = await _httpClient.PostAsync("api/employee", content);

		if (response.IsSuccessStatusCode)
		{
			return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
		}

		return null;
	}

	public async Task DeleteEmployee(int employeeId)
	{
		await _httpClient.DeleteAsync($"api/employee/{employeeId}");
	}

	public async Task<IEnumerable<Employee>> GetAllEmployees()
	{

		Stream stream = await _httpClient.GetStreamAsync($"api/employee");

		IEnumerable<Employee> employees = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

		return employees;
	}

	public async Task<Employee> GetEmployeeDetails(int employeeId)
	{
		Stream stream = await _httpClient.GetStreamAsync($"api/employee/{employeeId}");

		Employee employee = await JsonSerializer.DeserializeAsync<Employee>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

		return employee;
	}

	public async Task UpdateEmployee(Employee employee)
	{
		var employeeJson = JsonSerializer.Serialize(employee);
		var content = new StringContent(employeeJson, Encoding.UTF8, "application/json");
		
		HttpResponseMessage response = await _httpClient.PutAsync("api/employee", content);

		if (response.IsSuccessStatusCode)
		{
			return;
		}

		string responseContent = await response.Content.ReadAsStringAsync();
		return;
	}
}

