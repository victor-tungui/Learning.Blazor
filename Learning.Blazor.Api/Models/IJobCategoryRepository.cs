using System.Collections.Generic;


namespace Learning.Blazor.Api.Models;

public interface IJobCategoryRepository
{
	IEnumerable<JobCategory> GetAllJobCategories();
	JobCategory GetJobCategoryById(int jobCategoryId);
}

