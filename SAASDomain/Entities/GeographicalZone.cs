using System;
using System.Collections.Generic;
using System.Text;

namespace SAASDomain.Entities
{
    public class GeographicalZone
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
        public virtual ICollection<SubscriptionPackage> SubscriptionPackages { get; set; }
    }
}
