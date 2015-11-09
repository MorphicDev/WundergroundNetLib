﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Data
{
    public interface IWeatherStationCoordinates
    {
        double StationLatitude { get; set; }
        double StationLongitude { get; set; }
    }
}