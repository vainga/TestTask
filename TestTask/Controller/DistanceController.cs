using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TestTask.Service;
using Microsoft.AspNetCore.Mvc; 
using System.Text.Json;

namespace TestTask.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly IAirportService _airportService;
        private readonly IDistanceCalculator _distanceCalculator;

        public DistanceController(IAirportService airportService, IDistanceCalculator distanceCalculator)
        {
            _airportService = airportService;
            _distanceCalculator = distanceCalculator;
        }

        [HttpGet("{iataCode1}/{iataCode2}")]
        public async Task<IActionResult> GetDistance(string iataCode1, string iataCode2)
        {
            var airport1 = await _airportService.GetAirportDetailsAsync(iataCode1);
            var airport2 = await _airportService.GetAirportDetailsAsync(iataCode2);

            if (airport1 == null || airport2 == null)
            {
                return NotFound("Один или оба аэропорта не найдены.");
            }

            var distance = _distanceCalculator.CalculateDistance(airport1.Location, airport2.Location);

            var response = new DistanceResponse
            {
                Airport1 = airport1.Iata,
                Airport2 = airport2.Iata,
                DistanceMiles = distance
            };

            return Ok(response);
        }
    }

}
