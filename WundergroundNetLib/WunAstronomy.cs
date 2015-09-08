using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib
{
    // Created with: http://json2csharp.com/
    public class AstroFeatures
    {
        public int astronomy { get; set; }
    }

    public class AstroErro
    {
        public string type { get; set; }
    }

    public class AstroResponse
    {
        public string version { get; set; }
        public string termsofService { get; set; }
        public AstroFeatures features { get; set; }
        public AstroErro error { get; set; }
    }

    public class CurrentTime
    {
        public string hour { get; set; }
        public string minute { get; set; }
    }

    public class Sunrise
    {
        public string hour { get; set; }
        public string minute { get; set; }
    }

    public class Sunset
    {
        public string hour { get; set; }
        public string minute { get; set; }
    }

    public class MoonPhase
    {
        public string percentIlluminated { get; set; }
        public string ageOfMoon { get; set; }
        public string phaseofMoon { get; set; }
        public string hemisphere { get; set; }
        public CurrentTime current_time { get; set; }
        public Sunrise sunrise { get; set; }
        public Sunset sunset { get; set; }
    }

    public class Sunrise2
    {
        public string hour { get; set; }
        public string minute { get; set; }
    }

    public class Sunset2
    {
        public string hour { get; set; }
        public string minute { get; set; }
    }

    public class SunPhase
    {
        public Sunrise2 sunrise { get; set; }
        public Sunset2 sunset { get; set; }
    }

    public class WunAstronomy
    {
        public AstroResponse response { get; set; }
        public MoonPhase moon_phase { get; set; }
        public SunPhase sun_phase { get; set; }
    }
}
