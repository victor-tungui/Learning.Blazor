using Learning.Blazor.Services;
using Learning.Blazor.Shared;
using Microsoft.AspNetCore.Components;

namespace Learning.Blazor.Pages;

public partial class EmployeeEdit 
{

	[Inject]
	public IEmployeeDataService EmployeeDataService { get; set; }

	[Inject]
	public ICountryDataService CountryDataService { get; set; }

	[Inject]
	public IJobCategoryDataService JobCategoryDataService { get; set; }

	[Parameter]
	public string EmployeeId { get; set; } = string.Empty;

	public Employee Employee { get; set; } = new Employee();

	public List<Country> Countries { get; set; } = new List<Country>();
	public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

	protected string CountryId = string.Empty;
	protected string JobCategoryId = string.Empty;

	protected override async Task OnInitializedAsync()
	{
		Countries = (await CountryDataService.GetAllCountries()).ToList();
		JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();
		Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));

		CountryId = Employee.CountryId.ToString();
		JobCategoryId = Employee.JobCategoryId.ToString();
	}
}

