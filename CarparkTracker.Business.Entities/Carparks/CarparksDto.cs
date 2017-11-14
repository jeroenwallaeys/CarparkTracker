using System.Xml.Serialization;

namespace CarparkTracker.Business.Entities.Carparks
{
    [XmlRoot("ITSPS")]
    public class CarparksDto
    {
        [XmlElement("Agency")]
        public Agency Agency { get; set; }
    }
}
