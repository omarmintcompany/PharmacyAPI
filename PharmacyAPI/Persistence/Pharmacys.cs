using System;
using System.Collections.Generic;

namespace PharmacyAPI.Persistence
{
    public partial class Pharmacys
    {
        public int Id { get; set; }
        public string PharmacyName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
