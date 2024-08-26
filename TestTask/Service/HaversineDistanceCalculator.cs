using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Model;

namespace TestTask.Service
{
    public class HaversineDistanceCalculator : IDistanceCalculator
    {
        public double CalculateDistance(Location loc1, Location loc2)
        {
            var R = 3958.8; 
            var dLat = (loc2.Lat - loc1.Lat) * (Math.PI / 180.0);
            var dLon = (loc2.Lon - loc1.Lon) * (Math.PI / 180.0);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(loc1.Lat * (Math.PI / 180.0)) * Math.Cos(loc2.Lat * (Math.PI / 180.0)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
    }
}
