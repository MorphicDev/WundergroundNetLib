﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Data
{
    public interface ISunriseSunset
    {
        string Sunrise { get; set; }
        string Sunset { get; set; }
    }
}
