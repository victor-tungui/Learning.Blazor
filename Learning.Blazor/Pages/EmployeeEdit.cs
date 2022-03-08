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

	[Inject]
	public NavigationManager NavigationManager { get; set; }

	public Employee Employee { get; set; } = new Employee();

	public List<Country> Countries { get; set; } = new List<Country>();
	public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

	protected string CountryId = string.Empty;
	protected string JobCategoryId = string.Empty;

	//  UI Variables
	protected string Message = string.Empty;
	protected string StatusClass = string.Empty;
	protected bool Saved;

	protected override async Task OnInitializedAsync()
	{
		Saved = false;
		Countries = (await CountryDataService.GetAllCountries()).ToList();
		JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();		

		int.TryParse(EmployeeId, out int employeeId);

		if (employeeId == 0)
		{
			Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now  };
		} 
		else
		{
			Employee = await EmployeeDataService.GetEmployeeDetails(employeeId);
		}

		CountryId = Employee.CountryId.ToString();
		JobCategoryId = Employee.JobCategoryId.ToString();
	}

	protected async Task HandleValidSubmit()
	{
		Saved = false;
		Employee.CountryId = int.Parse(CountryId);
		Employee.JobCategoryId = int.Parse(JobCategoryId);

		Employee.Country = Countries.FirstOrDefault(c => c.CountryId == Employee.CountryId);
		Employee.JobCategory = JobCategories.FirstOrDefault(jc => jc.JobCategoryId == Employee.JobCategoryId);


		if (Employee.EmployeeId == 0)
		{
			var addedEmployee = await EmployeeDataService.AddEmployee(Employee);

			if (addedEmployee != null)
			{
				StatusClass = "alert-success";
				Message = "New employee added successfuly";
				Saved = true;
			} else
			{
				StatusClass = "alert-danger";
				Message = "Something went wrong adding the new employee. Please try again";
				Saved = false;
			}
		}
		else
		{
			await EmployeeDataService.UpdateEmployee(Employee);
			StatusClass = "alert-success";
			Message = "Employee updated successfully";
			Saved = true;
		}
	}

	protected void HandleInvalidSubmit()
	{
		StatusClass = "alert-danger";
		Message = "There are some validation errores. Please try again";
	}

	protected async Task DeleteEmployee()
	{
		await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);

		StatusClass = "alert-success";
		Message = "Deleted successfully";

		Saved = true;
	}

	protected void NavigateOverview()
	{
		NavigationManager.NavigateTo("/employeeoverview");
	}
}

