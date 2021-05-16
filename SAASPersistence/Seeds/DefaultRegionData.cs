using SAASDomain.Entities;
using System.Collections.Generic;

namespace SAASPersistence.Seeds
{
    public static class DefaultRegionData
    {
        public static List<Region> RegionDataList()
        {
            return new List<Region>
            {
                 new Region
                 {
                     Id = 1,
                     Name = "UK",
                     Vat = 15,
                     GeographicalZoneId = 1
                 },
                 new Region
                 {
                     Id = 2,
                     Name = "EU",
                     Vat = 18,
                     GeographicalZoneId = 1
                 },
                 new Region
                 { 
                     Id = 3, 
                     Name = "USA",
                     Vat = 0,
                     GeographicalZoneId = 2
                 }
            };
        }
    }
}
