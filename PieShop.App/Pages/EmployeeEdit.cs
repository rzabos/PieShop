using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using PieShop.App.Services;

namespace PieShop.App.Pages
{
    public partial class EmployeeEdit
    {
        public string CountryId = string.Empty;

        public string JobCategoryId = string.Empty;

        public IEnumerable<Country> Countries { get; set; } = new List<Country>();

        [Inject]
        public ICountryDataService CountryDataService { get; set; }

        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        public IEnumerable<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(Convert.ToInt32(EmployeeId));
            Countries = await CountryDataService.GetAllCountries();
            JobCategories = await JobCategoryDataService.GetAllJobCategories();
            CountryId = Employee.CountryId.ToString();
            JobCategoryId = Employee.JobCategoryId.ToString();
            await base.OnInitializedAsync();
        }
    }
}