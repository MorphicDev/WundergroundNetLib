﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Data
{
    public interface IForecastTemp
    {
        double HighCelcius { get; set; }
        double LowCelcius { get; set; }
    }
}
