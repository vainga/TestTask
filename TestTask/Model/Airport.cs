using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Model
{
    public class Airport
    {
        public string Iata { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
    }
}
