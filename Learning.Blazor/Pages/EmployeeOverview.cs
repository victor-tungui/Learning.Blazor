using Learning.Blazor.Services;
using Learning.Blazor.Shared;
using Microsoft.AspNetCore.Components;

namespace Learning.Blazor.Pages
{
	public partial class EmployeeOverview
	{
		public IEnumerable<Employee> Employees { get; set; }

		[Inject]
		public IEmployeeDataService EmployeeDataService { get; set; }

		protected override async Task OnInitializedAsync()
		{

			this.Employees = (await this.EmployeeDataService.GetAllEmployees()).ToList();
		}
	}
}
