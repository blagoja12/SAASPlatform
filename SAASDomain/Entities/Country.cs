using System;
using System.Collections.Generic;

namespace SAASDomain.Entities
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
