using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace PieShop.App.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;

        public EmployeeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllEmployees() => _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/employee");

        public Task<Employee> GetEmployeeDetails(int employeeId) => _httpClient.GetFromJsonAsync<Employee>($"api/employee/{employeeId}");

        public Task UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}