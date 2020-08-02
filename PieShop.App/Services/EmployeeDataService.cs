using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync("api/employee", employee);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Error while adding the employee.");
            }

            return JsonSerializer.Deserialize<Employee>(await response.Content.ReadAsStringAsync());
        }

        public Task DeleteEmployee(int employeeId) => _httpClient.DeleteAsync($"api/employee/{employeeId}");

        public Task<IEnumerable<Employee>> GetAllEmployees() => _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/employee");

        public Task<Employee> GetEmployeeDetails(int employeeId) => _httpClient.GetFromJsonAsync<Employee>($"api/employee/{employeeId}");

        public Task UpdateEmployee(Employee employee) => _httpClient.PutAsJsonAsync("api/employee", employee);
    }
}