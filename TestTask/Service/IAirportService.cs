using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Model;

namespace TestTask.Service
{
    public interface IAirportService
    {
        Task<Airport> GetAirportDetailsAsync(string iataCode);
    }
}
