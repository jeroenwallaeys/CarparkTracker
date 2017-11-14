using System.Xml.Serialization;

namespace CarparkTracker.Business.Entities.Carparks
{
    public class Agency
    {
        [XmlArray("Carparks")]
        public CarparkDto[] Carparks { get; set; }

        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string Location { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int TimeZone { get; set; }
        public string Website { get; set; }
    }
}
