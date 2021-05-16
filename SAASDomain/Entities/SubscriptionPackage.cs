using System;
using System.Collections.Generic;

namespace SAASDomain.Entities
{
    public class SubscriptionPackage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal MonthlyPrice { get; set; }
        public decimal YearlyPrice { get; set; }
        public int GeographicalZoneId { get; set; }

        public virtual GeographicalZone GeographicalZone { get; set; }
    }
}
