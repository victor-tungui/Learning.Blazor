using Learning.Blazor.Services;
using Learning.Blazor.Shared;
using Microsoft.AspNetCore.Components;

namespace Learning.Blazor.Pages;

public partial class EmployeeDetail
{
	[Parameter]
	public string EmployeeId { get; set; }

	[Inject]
	public IEmployeeDataService EmployeeDataService { get; set; }

	public Employee Employee { get; set; } = new Employee();

	protected override async Task OnInitializedAsync()
	{
		this.Employee = await this.EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
	}
}

