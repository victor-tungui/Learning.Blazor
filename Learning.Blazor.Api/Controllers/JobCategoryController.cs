using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Blazor.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobCategoryController : ControllerBase
{
	private readonly IJobCategoryRepository _jobCategoryRepository;

	public JobCategoryController(IJobCategoryRepository jobCategoryRepository)
	{
		_jobCategoryRepository = jobCategoryRepository;
	}


	// GET: api/<controller>
	[HttpGet]
	public IActionResult GetJobCategories()
	{
		return Ok(_jobCategoryRepository.GetAllJobCategories());
	}

	// GET api/<controller>/5
	[HttpGet("{id}")]
	public IActionResult GetJobCategoryById(int id)
	{
		return Ok(_jobCategoryRepository.GetJobCategoryById(id));
	}
}

