namespace CarparkTracker.Business.Entities.Carparks
{
    public class Carpark
    {
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string Location { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string DefaultLanguage { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Capacity { get; set; }
        public int Floors { get; set; }
        public string ParkingType { get; set; }
        public string FreeText { get; set; }
    }
}