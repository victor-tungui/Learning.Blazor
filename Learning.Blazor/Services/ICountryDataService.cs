using Learning.Blazor.Shared;

namespace Learning.Blazor.Services;

public interface ICountryDataService
{
	Task<IEnumerable<Country>> GetAllCountries();

	Task<Country> GetCountryById(int countryId);
}

