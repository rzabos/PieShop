using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using PieShop.App.Components;
using PieShop.App.Services;

namespace PieShop.App.Pages
{
    public class EmployeeOverviewBase : ComponentBase
    {
        public AddEmployeeDialog AddEmployeeDialog { get; set; }

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public async void AddEmployeeDialog_OnDialogClose()
        {
            Employees = await EmployeeDataService.GetAllEmployees();
            StateHasChanged();
        }

        public void QuickAddEmployee()
        {
            AddEmployeeDialog.Show();
        }

        protected override async Task OnInitializedAsync()
        {
            Employees = await EmployeeDataService.GetAllEmployees();

            await base.OnInitializedAsync();
        }
    }
}