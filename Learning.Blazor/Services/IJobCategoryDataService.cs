using Learning.Blazor.Shared;

namespace Learning.Blazor.Services;

public interface IJobCategoryDataService
{
	Task<IEnumerable<JobCategory>> GetAllJobCategories();

	Task<JobCategory> GedtJobCategoryById(int jobCategoryId);
}

