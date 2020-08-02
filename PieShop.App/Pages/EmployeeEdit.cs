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
        protected string CountryId = string.Empty;
        protected string JobCategoryId = string.Empty;
        protected string Message = string.Empty;
        protected bool Saved;
        protected string StatusClass = string.Empty;

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

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected override async Task OnInitializedAsync()
        {
            // Employee = await EmployeeDataService.GetEmployeeDetails(Convert.ToInt32(EmployeeId));
            Countries = await CountryDataService.GetAllCountries();
            JobCategories = await JobCategoryDataService.GetAllJobCategories();
            int.TryParse(EmployeeId, out var id);
            if (id == 0)
            {
                Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now };
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(Convert.ToInt32(EmployeeId));
            }

            CountryId = Employee.CountryId.ToString();
            JobCategoryId = Employee.JobCategoryId.ToString();
            await base.OnInitializedAsync();
        }

        private async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);
            StatusClass = "alert-success";
            Message = "Deleted successfully";
            Saved = true;
        }

        private async Task HandleValidSubmit()
        {
            Saved = false;
            Employee.CountryId = int.Parse(CountryId);
            Employee.JobCategoryId = int.Parse(JobCategoryId);

            if (Employee.EmployeeId == 0) //new
            {
                var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Employee updated successfully.";
                Saved = true;
            }
        }

        private void NavigateToOverview() => NavigationManager.NavigateTo("/employeeoverview");
    }
}