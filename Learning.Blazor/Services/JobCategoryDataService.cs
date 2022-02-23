using Learning.Blazor.Shared;
using System.Text.Json;

namespace Learning.Blazor.Services;

public class JobCategoryDataService : IJobCategoryDataService
{
	private readonly HttpClient _httpClient;

	public JobCategoryDataService(HttpClient httpClient)
	{
		this._httpClient = httpClient;
	}

	public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
	{
		Stream jobCategoriesStream = await _httpClient.GetStreamAsync($"api/JobCategory");

		return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>(jobCategoriesStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
	}

	public async Task<JobCategory> GedtJobCategoryById(int jobCategoryId)
	{
		Stream jobCategoryStream = await _httpClient.GetStreamAsync($"api/JobCategory/{jobCategoryId}");

		return await JsonSerializer.DeserializeAsync<JobCategory>(jobCategoryStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
	}
}

