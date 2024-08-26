﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Model;

namespace TestTask.Service
{
    public interface IDistanceCalculator
    {
        double CalculateDistance(Location loc1, Location loc2);
    }
}
