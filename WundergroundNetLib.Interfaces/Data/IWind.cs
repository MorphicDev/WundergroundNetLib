using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Data
{
    public interface IWind
    {
        string WindDirection { get; set; }
        int WindDegrees { get; set; }
        double WindAvgKph { get; set; }
        double WindGustKph { get; set; }
    }
}
