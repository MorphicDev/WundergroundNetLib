namespace WundergroundNetLib.Interfaces
{
    public interface IObservationLocation
    {
        string City { get; set; }
        string Country { get; set; }
        string StationElevation { get; set; }
        string StationID { get; set; }
        double StationLatitude { get; set; }
        double StationLongitude { get; set; }
        int WmoNumber { get; set; }
    }
}