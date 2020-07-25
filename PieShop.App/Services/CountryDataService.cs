using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace PieShop.App.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;

        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Country>> GetAllCountries() => _httpClient.GetFromJsonAsync<IEnumerable<Country>>("api/country");

        public Task<Country> GetCountryById(int countryId) => _httpClient.GetFromJsonAsync<Country>("api/country/{countryId}");
    }
}