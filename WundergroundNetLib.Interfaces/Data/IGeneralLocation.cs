using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Data
{
    public interface IGeneralLocation
    {
        string City { get; set; }
        string Country { get; set; }
    }
}
