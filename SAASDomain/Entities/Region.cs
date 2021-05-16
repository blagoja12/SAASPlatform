using System;
using System.Collections.Generic;

namespace SAASDomain.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Vat { get; set; }
        public int GeographicalZoneId { get; set; }

        public virtual GeographicalZone GeographicalZone { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}
