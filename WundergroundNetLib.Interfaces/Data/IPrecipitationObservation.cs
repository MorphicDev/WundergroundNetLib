﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Data
{
    public interface IPrecipitationObservation
    {
        double PrecipLastHr { get; set; }
        double PrecipToday { get; set; }
    }
}
