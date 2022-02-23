using Learning.Blazor.Shared;
using System.Text.Json;

namespace Learning.Blazor.Services;

public class CountryDataService : ICountryDataService
{
	private readonly HttpClient _httpClient;

	public CountryDataService(HttpClient httpClient)
	{
		this._httpClient = httpClient;
	}

	public async Task<IEnumerable<Country>> GetAllCountries()
	{
		Stream countriesStream = await _httpClient.GetStreamAsync($"api/country");

		return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>(countriesStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

	}

	public async Task<Country> GetCountryById(int countryId)
	{
		Stream countryStream = await _httpClient.GetStreamAsync($"api/country/{countryId}");

		return await JsonSerializer.DeserializeAsync<Country>(countryStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
	}
}

