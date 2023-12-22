using System.ComponentModel.DataAnnotations;

namespace PharmacyAPI.Resources.Query
{
    public class PharmacyListQuery
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
