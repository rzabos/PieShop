using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace PieShop.App.Services
{
    public class JobCategoryDataService : IJobCategoryDataService
    {
        private readonly HttpClient _httpClient;

        public JobCategoryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<JobCategory>> GetAllJobCategories() => _httpClient.GetFromJsonAsync<IEnumerable<JobCategory>>("api/jobcategory");

        public Task<JobCategory> GetJobCategoryById(int jobCategoryId) => _httpClient.GetFromJsonAsync<JobCategory>($"api/jobcategory/{jobCategoryId}");
    }
}