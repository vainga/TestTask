using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Model;
using System.Text.Json;

namespace TestTask.Service
{
    public class AirportService : IAirportService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://places-dev.cteleport.com/airports/";

        public AirportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Airport> GetAirportDetailsAsync(string iataCode)
        {
            var response = await _httpClient.GetStringAsync($"{_apiBaseUrl}{iataCode}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<Airport>(response, options);
        }
    }
}
